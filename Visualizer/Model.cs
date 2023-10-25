using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.Visualizer.UI;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;

namespace AgGateway.ADAPT.Visualizer
{
    public class Model
    {
        private readonly Action<State, string> _updateStatusAction;

        public enum State
        {
            StateIdle,
            StateImporting,
            StateExporting,
            StateValidating
        };

        private readonly DataProvider _dataProvider;
        private int _admIndex;
        private static TreeView _treeView;

        private string _findWhat;
#if detectCircularRecursions
        private long _findId;
#endif  // detectCircularRecursions 

        private State _currentState;
        public State CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                if (_currentState == State.StateImporting && value == State.StateIdle)
                    ShowMessageBox(@"Import Complete");

                if(_currentState == State.StateExporting && value == State.StateIdle)
                    ShowMessageBox(@"Data exported successfully.");

                _currentState = value;
            }
        }

        public Model(Action<State, string> updateStatusAction)
        {
            _updateStatusAction = updateStatusAction;
            _dataProvider = new DataProvider();
            ApplicationDataModels = new List<ApplicationDataModel.ADM.ApplicationDataModel>();

            CurrentState = State.StateIdle;
        }

        public IList<ApplicationDataModel.ADM.ApplicationDataModel> ApplicationDataModels { get; private set; }

        public ObservableCollection<KeyValuePair<string, string>> AvailablePlugins()
        {
            if (_dataProvider == null)
                return new ObservableCollection<KeyValuePair<string, string>>();

            return new ObservableCollection<KeyValuePair<string, string>>(_dataProvider.AvailablePlugins);
        }

        public ObservableCollection<KeyValuePair<string, string>> LoadPlugins(TextBox textBox)
        {
            var availablePlugins = new ObservableCollection<KeyValuePair<string, string>>();

            if (IsValid(textBox, "Plugin"))
            {
                _dataProvider.Initialize(textBox.Text);

                if (_dataProvider.AvailablePlugins != null)
                {
                    availablePlugins = _dataProvider.AvailablePlugins;
                }
            }

            return availablePlugins;
        }

        public bool ArePluginsLoaded(TextBox pluginPathTextBox)
        {
            if (_dataProvider.PluginFactory == null)
            {
                MessageBox.Show(@"Select a valid plugin path and load them before importing a datacard.");
                pluginPathTextBox.Focus();
                return false;
            }

            return true;
        }

        public void Export(string pluginName, string initializeString, string exportPath, string cardProfileSelectedText, ApplicationDataModel.ADM.Properties properties)
        {
            try
            {
                var plugin = _dataProvider.GetPlugin(pluginName);

                if (ApplicationDataModels == null || ApplicationDataModels.Count == 0 || plugin == null)
                {
                    MessageBox.Show(@"Could not export, either not a comptable plugin or no data model to export");
                    return;
                }

                Task.Run(() =>
                {

                    CurrentState = State.StateExporting;
                    _updateStatusAction(CurrentState, "Export in Progress");

                    var selectApplicationDataModel =
                        ApplicationDataModels.First(
                            x => x.Catalog.Description.ToLower().Equals(cardProfileSelectedText.ToLower()));
                    DataProvider.Export(plugin, 
                                        selectApplicationDataModel, 
                                        initializeString,
                                        GetExportDirectory(exportPath), 
                                        properties);

                    CurrentState = State.StateIdle;
                    _updateStatusAction(CurrentState, "Done");
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void FindInTree(TreeView treeView, string findWhat)
        {
            _findWhat = findWhat;
#if detectCircularRecursions
            _findId = DateTime.Now.Ticks;
#endif  // detectCircularRecursions 
            FindNextInTree(treeView);
        }

        public void FindNextInTree(TreeView treeView)
        {
            if (string.IsNullOrEmpty(_findWhat)) return;
            if (treeView.Nodes.Count <= 0) return;

            Cursor.Current = Cursors.WaitCursor;

            // If currently no node is selected take the first one.
            if (treeView.SelectedNode == null) treeView.SelectedNode = treeView.Nodes[0];

            TreeNode node = _findWorker(treeView.SelectedNode, true);
            if (node != null)
                treeView.SelectedNode = node;
            else
                System.Media.SystemSounds.Beep.Play();

            Cursor.Current = Cursors.Default;
        }

        private TreeNode _findWorker(TreeNode nodeA, bool isStartNode = false)
        {
            TreeNode result = null;

            if (!isStartNode)   // Only test the current node if it's NOT the start node!
            {
#if detectCircularRecursions
                System.Diagnostics.Debug.Print($"{nodeA.Level:0} {nodeA.Text}");
                long? id = nodeA.Tag as long?;
                if (id.HasValue)
                {
                    System.Diagnostics.Debug.Assert(id != _findId, "Circular recursion :-O");
                    return null;
                }
                else
                {
                    nodeA.Tag = _findId;    // WATCH OUT: Tag is being used for something else and overwritten here!
                }
#endif  // detectCircularRecursions 

                if (nodeA.Text.IndexOf(_findWhat, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    result = nodeA;
                }
            }

            if (result == null)
            {
                // No match. Do I have children?
                TreeNode firstChild = nodeA.FirstNode;
                if (firstChild != null) result = _findWorker(firstChild);
            }
            if (result == null)
            {
                // No match. Do I have siblings?
                TreeNode sibling = nodeA.NextNode;
                if (sibling != null) result = _findWorker(sibling);
            }
            if ((result == null) && (isStartNode)) 
            {
                // If I'm the start node I also try to walk up the parent line towards the root.
                TreeNode parent = nodeA.Parent;
                while (parent != null)
                {
                    // The parent itself isn't relevant. It's the first sibling of the parent
                    // I do continue the search.
                    TreeNode parentSibling = parent.NextNode;
                    if (parentSibling != null) result = _findWorker(parentSibling);

                    if (result != null) break;
                    // Further towards the root of the tree.
                    parent = parent.Parent;
                }
            }
            return result;
        }

        public bool Import(TextBox dataCardTextBox, string initializeString, TreeView treeView, ApplicationDataModel.ADM.Properties properties)
        {
            if (IsValid(dataCardTextBox, "Datacard"))
            {
                CurrentState = State.StateImporting;
                treeView.BeginUpdate();

                ImportDataCard(dataCardTextBox.Text, initializeString, treeView, properties);

                treeView.EndUpdate();

                return true;
            }

            return false;  
        }

        private void ShowMessageBox(string message)
        {
            _treeView.Invoke(new Action(() => MessageBox.Show(message)));
        }

        private void ImportDataCard(string datacardPath, string initializeString, TreeView treeView, ApplicationDataModel.ADM.Properties properties)
        {
            _treeView = treeView;

            Task.Run(() =>
            {
                DateTime start = DateTime.Now;  //170629 MSp

                _updateStatusAction(CurrentState, "Starting Import");

                ApplicationDataModels = _dataProvider.Import(datacardPath, initializeString, properties);
                if (ApplicationDataModels == null || ApplicationDataModels.Count == 0)
                {
                    MessageBox.Show(@"Not supported data format.");
                    CurrentState = State.StateIdle;
                    _updateStatusAction(CurrentState, "Done");
                    return;
                }

                _admIndex = 0;
                for (; _admIndex < ApplicationDataModels.Count; _admIndex++)
                {
                    var applicationDataModel = ApplicationDataModels[_admIndex];

                    applicationDataModel.Documents?.LoggedData.SelectMany(x => x.OperationData.ToList()).ToList();
                    
                    var parentNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => treeView.Nodes.Add("ApplicationDataModel")));

                    AddNode(applicationDataModel, parentNode);
                }
                
                CurrentState = State.StateIdle;
                _updateStatusAction(CurrentState, "Done");

                //170629 MSp How long did it take to parse the data model into the tree?
                DateTime stop = DateTime.Now;
                TimeSpan duration = new TimeSpan(stop.Ticks - start.Ticks);
                System.Diagnostics.Debug.Print($"ImportDataCard had a duration of {duration.Seconds:#,##0.0}.");
            });
        }

        public void ValidateDataOnCard(TextBox dataCardTextBox, string initializeString, Form parent)
        {
            if (IsValid(dataCardTextBox, "Datacard"))
            {
                CurrentState = State.StateValidating;

                IList<AgGateway.ADAPT.ApplicationDataModel.ADM.IError> errors = _dataProvider.ValidateDataOnCard(dataCardTextBox.Text, initializeString);

                ValidateForm validateForm = new ValidateForm();
                validateForm.LoadData(errors);
                validateForm.ShowDialog(parent);

                CurrentState = State.StateIdle;
            }
        }


        private void AddNode(object element, TreeNode parentNode)
        {
            if (element == null)
                return;

            var type = element.GetType();
            type = CheckType(ref element, type);
            foreach (var propertyInfo in type.GetProperties())
            {
                ParseProperty(element, parentNode, propertyInfo);
            }
        }

       

        private static Type CheckType(ref object element, Type type)
        {
            if (!type.Namespace.StartsWith("System") && !type.Namespace.StartsWith("AgGateway.ADAPT.ApplicationDataModel"))
            {
                type = type.BaseType;
                element = Convert.ChangeType(element, type);
            }
            return type;
        }

        private void ParseProperty(object element, TreeNode parentNode, PropertyInfo propertyInfo)
        {
            if (element is Func<object> || element is Func<int, object> || element is Action)
                return;

            var propertyType = propertyInfo.PropertyType;

            var underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (propertyType.IsGenericType && underlyingType != null)
            {
                propertyType = underlyingType;
            }

            var propertyValue = propertyInfo.GetIndexParameters().Any() ? null : propertyInfo.GetValue(element, null);

            propertyType = CheckType(ref propertyValue, propertyType);

            if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime) || propertyType.IsEnum)
            {
                _treeView.Invoke(new Action(() => parentNode.Nodes.Add(String.Format(@"{0}: {1}", propertyInfo.Name,
                    propertyValue))));
            }
            else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
            {
                ParseArrays(parentNode, propertyInfo, propertyValue);
            }
            else
            {
                string nodeText = _extendNodeText(propertyInfo.Name, propertyValue, propertyType);                      //170623 MSp 
                var childNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => parentNode.Nodes.Add(nodeText)));   //170623 MSp 
                //170623 MSp var childNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => parentNode.Nodes.Add(propertyInfo.Name)));
                parentNode.Tag = new ObjectWithIndex(_admIndex, element);

                AddNode(propertyValue, childNode);
            }
        }


        private void ParseArrays(TreeNode parentNode, PropertyInfo propertyInfo, object propertyValue)
        {

            _updateStatusAction(CurrentState, "Parsing: " + propertyInfo.Name);

            var collectionNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => parentNode.Nodes.Add(propertyInfo.Name)));
            var collection = (IEnumerable)propertyValue;
            if (collection != null)
            {
                if (collection is IEnumerable<WorkingData> || collection is IEnumerable<DeviceElementUse> || collection is IEnumerable<DataLogTrigger> || collection is IEnumerable<RxCellLookup>)
                    return;

                foreach (var child in collection)
                {
                    string nodeText;            //190502 MSp
                    if (child == null)          //190502 MSp
                    {                           //190502 MSp
                         nodeText = "#null#";   //190502 MSp
                    }                           //190502 MSp
                    else                        //190502 MSp
                    {                           //190502 MSp
                        var childObject = child;
                        var type = CheckType(ref childObject, childObject.GetType());
                        nodeText = _extendNodeText(type.Name, childObject, type);    
                    }                           //190429 MS
                    var node = new TreeNode(nodeText)                                   //170623 MSp 
                    {
                        Tag = new ObjectWithIndex(_admIndex, child)
                    };

                    _treeView.Invoke(new Action(() => collectionNode.Nodes.Add(node)));
                    AddNode(child, node);
                }
            }
        }

        private string _extendNodeText(string nodeText, object obj, Type type)
        {
            if (obj == null) return nodeText;

            // Don't know if thats very fancy code - but also for Int32 I'd like
            // to see their value.
            // For all other objects I try to add ReferenceId and one of Description,
            // Name or LastName.

            if (nodeText.IndexOf(':') >= 0) // Don't overwrite existing Values
            {
                System.Diagnostics.Debug.Assert(false, "Does this ever happen?");
                return nodeText;    
            }

            // OK, Text property doesn't hold a value...
            if (obj is Int32) // Is it a Int32?
            {
                Int32 n = (Int32)obj;
                nodeText += $": {n}";
            }
            else
            {
                List<string> addenum = new List<string>();

                // Special handling for ContextItems.
                // Show Code and Value. Indicate nested items with a +.
                if (obj is ContextItem)
                {
                    ContextItem ci = (ContextItem)obj;
                    if (!string.IsNullOrWhiteSpace(ci.Code)) addenum.Add(ci.Code);
                    if (!string.IsNullOrWhiteSpace(ci.Value)) addenum.Add(ci.Value);
                    if (ci.NestedItems.Count > 0) addenum.Add("+");
                }
                // Special handling for MeteredValue with NumericRepresentation
                // Show the Code of the NumericRepresentationValue (vrTotalAreaCovered, ...) as 
                // well as Value (Value.Value) and Code (Value.UnitOfMeasure.Code).
                else if ((obj is MeteredValue) && (((MeteredValue)obj).Value is NumericRepresentationValue))
                {
                    NumericRepresentationValue nrv = (NumericRepresentationValue)((MeteredValue)obj).Value;
                    if (!string.IsNullOrWhiteSpace(nrv.Representation.Code)) addenum.Add(nrv.Representation.Code);
                    // For NumericValue there is also a dedicated block some lines down :-/
                    NumericValue nv = nrv.Value;
                    if (!string.IsNullOrWhiteSpace(nv.UnitOfMeasure.Code))
                        addenum.Add($"{nv.Value:#,##0.####} {nv.UnitOfMeasure.Code}");
                }
                else
                {
                    // Generic handling for all types

                    // Add value of ReferenceId
                    PropertyInfo pi = type.GetProperty("Id");
                    if (pi != null)
                    {
                        CompoundIdentifier ci = pi.GetValue(obj) as CompoundIdentifier;
                        if (ci != null) addenum.Add(ci.ReferenceId.ToString());
                    }
                    // Add one of the following...
                    pi = type.GetProperty("Description");
                    if (pi == null) pi = type.GetProperty("Name");
                    if (pi == null) pi = type.GetProperty("LastName");
                    if (pi != null)
                    {
                        string designator = pi.GetValue(obj) as string;
                        if (designator != null) addenum.Add(designator);
                    }

                    // Additional handling for TimeScope
                    if (obj is TimeScope)
                    {
                        TimeScope ts = (TimeScope)obj;
                        addenum.Add($"dcx {ts.DateContext}");
                        if (ts.TimeStamp1.HasValue) addenum.Add($"ts1 {ts.TimeStamp1.Value.ToNiceDateTime()}");
                        if (ts.TimeStamp2.HasValue) addenum.Add($"ts2 {ts.TimeStamp2.Value.ToNiceDateTime()}");
                        if (ts.Duration.HasValue) addenum.Add($"d {ts.Duration}");
                    }
                    // Additional handling for NumericRepresentationValue
                    else if (obj is NumericRepresentationValue)
                    {
                        NumericValue nv = ((NumericRepresentationValue)obj).Value;
                        if (nv.UnitOfMeasure != null && !string.IsNullOrWhiteSpace(nv.UnitOfMeasure.Code))
                            addenum.Add($"{nv.Value:#,##0.####} {nv.UnitOfMeasure.Code}");
                    }
                }

                if (addenum.Count > 0)
                {
                    nodeText += " [" + String.Join(", ", addenum) + "]";
                }
            }

            return nodeText;
        }

        private bool IsValid(TextBox textBox, string text)
        {
            if (textBox.Text == null || !Directory.Exists(textBox.Text))
            {
                MessageBox.Show(String.Format(@"Select a valid {0} path.", text));
                textBox.Focus();
                return false;
            }

            return true;
        }

        private string GetExportDirectory(string exportPath)
        {
            return exportPath != String.Empty ? exportPath : "C:\\newfile.zip";
        }

        public static void BrowseFolderDialog(IWin32Window parent, TextBox textBox, string description = "")
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = description;
                folderBrowserDialog.SelectedPath = textBox.Text;
                if (folderBrowserDialog.ShowDialog(parent) == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        public void WriteCsvFile(string fileName, DataTable dataTable)
        {
            int columnCount = dataTable.Columns.Count;
            using (var streamWriter = new StreamWriter(fileName))
            {
                var sb = new StringBuilder();

                for (int i = 0; i < columnCount; i++)
                {
                    if (i != 0)
                        sb.Append(",");

                    sb.Append(dataTable.Columns[i].ColumnName);
                }
                streamWriter.WriteLine(sb.ToString());

                foreach (DataRow row in dataTable.Rows)
                {
                    sb.Clear();
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (j != 0)
                            sb.Append(",");

                        sb.Append(row[j]);
                    }
                    streamWriter.WriteLine(sb.ToString());
                }

                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}

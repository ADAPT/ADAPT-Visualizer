# ADAPT-Visualizer

The ADAPT Visualizer is a .Net WinForms Utility that includes the ability to import data from a valid plugin, navigate a tree-view control, display grids and themed spatial data, and export the data.  Desired improvements in the form of pull requests welcome.

## Import
 1. Click the Import button.
 2. On the import dialog
    a. Browse to a directory that contains a valid ADAPT Plugin and click Load Plugins
    b. Click Load Plugins
    c. One or more Plugins should show up.
    d. Browse to the source of the data and click Import.
 3. A small "Import complete" dialog will pop up when complete.  Note, if you have changed focus during the import, you won't see this popup automatically.
 4. Data will display in a tree view at left, reflecting the ADAPT Framework ApplicationDataModel.   
 5. Where LoggedData exists with spatial detail, expand Documents, LoggedData and OperationData.  
    a. Having selected an OperationData entity, the Visualizer will display a spatial view and grid view in the main window.
    b. The "map" may be themed using the dropdown at the top of that tab.
    c. The grid may be sorted by clicking the column headings.

## Export
1. Import Data.
2. Click the Export button.
3. On the export dialog
    a. Browse to a directory that contains a valid ADAPT Plugin and click Load Plugins
    b. Click Load Plugins
    c. Select the desired Export plugin
    d. Click export.

Note: Due to how this utility uses MEF discoverability of plugins vs. direct references, a known issue is handling of the ADAPT RepresentationSystem.xml and UnitOfMeasureSystem.xml files (and the two additional resources required by the ISOv4Plugin).   You may need to manually copy these from the ADAPT framework into a /Resources directory in the runtime directory of the Visualizer.

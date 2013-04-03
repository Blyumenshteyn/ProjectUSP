//==============================================================================
//  WARNING!!  This file is overwritten by the Block UI Styler while generating
//  the automation code. Any modifications to this file will be lost after
//  generating the code again.
//
//       Filename:  C:\ug_customization\application\dialogs\dialogWith2Points.cs
//
//        This file was generated by the NX Block UI Styler
//        Created by: USP
//              Version: NX 7.5
//              Date: 03-22-2013  (Format: mm-dd-yyyy)
//              Time: 15:37 (Format: hh-mm)
//
//==============================================================================

//==============================================================================
//  Purpose:  This TEMPLATE file contains C# source to guide you in the
//  construction of your Block application dialog. The generation of your
//  dialog file (.dlx extension) is the first step towards dialog construction
//  within NX.  You must now create a NX Open application that
//  utilizes this file (.dlx).
//
//  The information in this file provides you with the following:
//
//  1.  Help on how to load and display your Block UI Styler dialog in NX
//      using APIs provided in NXOpen.BlockStyler namespace
//  2.  The empty callback methods (stubs) associated with your dialog items
//      have also been placed in this file. These empty methods have been
//      created simply to start you along with your coding requirements.
//      The method name, argument list and possible return values have already
//      been provided for you.
//==============================================================================

//------------------------------------------------------------------------------
//These imports are needed for the following template code
//------------------------------------------------------------------------------
using System;
using NXOpen;
using NXOpen.BlockStyler;
using NXOpen.Assemblies;

//------------------------------------------------------------------------------
//Represents Block Styler application class
//------------------------------------------------------------------------------
public class dialogWith2Points
{
    //class members
    private static Session theSession = null;
    private static UI theUI = null;
    public static dialogWith2Points thedialogWith2Points;
    private string theDialogName;
    private NXOpen.BlockStyler.BlockDialog theDialog;
    private NXOpen.BlockStyler.UIBlock group02;// Block type: Group
    private NXOpen.BlockStyler.UIBlock selection0;// Block type: Selection
    private NXOpen.BlockStyler.UIBlock point0;// Block type: Specify Point
    private NXOpen.BlockStyler.UIBlock group0;// Block type: Group
    private NXOpen.BlockStyler.UIBlock selection01;// Block type: Selection
    private NXOpen.BlockStyler.UIBlock point1;// Block type: Specify Point
    private NXOpen.BlockStyler.UIBlock direction0;// Block type: Reverse Direction
    //------------------------------------------------------------------------------
    //Bit Option for Property: SnapPointTypesEnabled
    //------------------------------------------------------------------------------
    public static readonly int              SnapPointTypesEnabled_UserDefined = (1 << 0);
    public static readonly int                 SnapPointTypesEnabled_Inferred = (1 << 1);
    public static readonly int           SnapPointTypesEnabled_ScreenPosition = (1 << 2);
    public static readonly int                 SnapPointTypesEnabled_EndPoint = (1 << 3);
    public static readonly int                 SnapPointTypesEnabled_MidPoint = (1 << 4);
    public static readonly int             SnapPointTypesEnabled_ControlPoint = (1 << 5);
    public static readonly int             SnapPointTypesEnabled_Intersection = (1 << 6);
    public static readonly int                SnapPointTypesEnabled_ArcCenter = (1 << 7);
    public static readonly int            SnapPointTypesEnabled_QuadrantPoint = (1 << 8);
    public static readonly int            SnapPointTypesEnabled_ExistingPoint = (1 << 9);
    public static readonly int             SnapPointTypesEnabled_PointonCurve = (1 <<10);
    public static readonly int           SnapPointTypesEnabled_PointonSurface = (1 <<11);
    public static readonly int         SnapPointTypesEnabled_PointConstructor = (1 <<12);
    public static readonly int     SnapPointTypesEnabled_TwocurveIntersection = (1 <<13);
    public static readonly int             SnapPointTypesEnabled_TangentPoint = (1 <<14);
    public static readonly int                    SnapPointTypesEnabled_Poles = (1 <<15);
    public static readonly int         SnapPointTypesEnabled_BoundedGridPoint = (1 <<16);
    //------------------------------------------------------------------------------
    //Bit Option for Property: SnapPointTypesOnByDefault
    //------------------------------------------------------------------------------
    public static readonly int          SnapPointTypesOnByDefault_UserDefined = (1 << 0);
    public static readonly int             SnapPointTypesOnByDefault_Inferred = (1 << 1);
    public static readonly int       SnapPointTypesOnByDefault_ScreenPosition = (1 << 2);
    public static readonly int             SnapPointTypesOnByDefault_EndPoint = (1 << 3);
    public static readonly int             SnapPointTypesOnByDefault_MidPoint = (1 << 4);
    public static readonly int         SnapPointTypesOnByDefault_ControlPoint = (1 << 5);
    public static readonly int         SnapPointTypesOnByDefault_Intersection = (1 << 6);
    public static readonly int            SnapPointTypesOnByDefault_ArcCenter = (1 << 7);
    public static readonly int        SnapPointTypesOnByDefault_QuadrantPoint = (1 << 8);
    public static readonly int        SnapPointTypesOnByDefault_ExistingPoint = (1 << 9);
    public static readonly int         SnapPointTypesOnByDefault_PointonCurve = (1 <<10);
    public static readonly int       SnapPointTypesOnByDefault_PointonSurface = (1 <<11);
    public static readonly int     SnapPointTypesOnByDefault_PointConstructor = (1 <<12);
    public static readonly int SnapPointTypesOnByDefault_TwocurveIntersection = (1 <<13);
    public static readonly int         SnapPointTypesOnByDefault_TangentPoint = (1 <<14);
    public static readonly int                SnapPointTypesOnByDefault_Poles = (1 <<15);
    public static readonly int     SnapPointTypesOnByDefault_BoundedGridPoint = (1 <<16);
    
    //--------------------------------------------------------------
    UspElement element1, element2;
    SlotSet slotSet1, slotSet2;
    Slot slot1, slot2;
    SlotConstraint constr;

    //------------------------------------------------------------------------------
    //Constructor for NX Styler class
    //------------------------------------------------------------------------------
    public dialogWith2Points()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theDialogName = @"C:\ug_customization\application\dialogWith2Points.dlx";
            theDialog = theUI.CreateDialog(theDialogName);
            theDialog.AddApplyHandler(new NXOpen.BlockStyler.BlockDialog.Apply(apply_cb));
            theDialog.AddOkHandler(new NXOpen.BlockStyler.BlockDialog.Ok(ok_cb));
            theDialog.AddUpdateHandler(new NXOpen.BlockStyler.BlockDialog.Update(update_cb));
            theDialog.AddCancelHandler(new NXOpen.BlockStyler.BlockDialog.Cancel(cancel_cb));
            theDialog.AddFilterHandler(new NXOpen.BlockStyler.BlockDialog.Filter(filter_cb));
            theDialog.AddInitializeHandler(new NXOpen.BlockStyler.BlockDialog.Initialize(initialize_cb));
            theDialog.AddFocusNotifyHandler(new NXOpen.BlockStyler.BlockDialog.FocusNotify(focusNotify_cb));
            theDialog.AddKeyboardFocusNotifyHandler(new NXOpen.BlockStyler.BlockDialog.KeyboardFocusNotify(keyboardFocusNotify_cb));
            theDialog.AddDialogShownHandler(new NXOpen.BlockStyler.BlockDialog.DialogShown(dialogShown_cb));
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            throw ex;
        }
    }
    //------------------------------- DIALOG LAUNCHING ---------------------------------
    //
    //    Before invoking this application one needs to open any part/empty part in NX
    //    because of the behavior of the blocks.
    //
    //    Make sure the dlx file is in one of the following locations:
    //        1.) From where NX session is launched
    //        2.) $UGII_USER_DIR/application
    //        3.) For released applications, using UGII_CUSTOM_DIRECTORY_FILE is highly
    //            recommended. This variable is set to a full directory path to a file 
    //            containing a list of root directories for all custom applications.
    //            e.g., UGII_CUSTOM_DIRECTORY_FILE=$UGII_ROOT_DIR\menus\custom_dirs.dat
    //
    //    You can create the dialog using one of the following way:
    //
    //    1. Journal Replay
    //
    //        1) Replay this file through Tool->Journal->Play Menu.
    //
    //    2. USER EXIT
    //
    //        1) Remove the following conditional definitions:
    //                a) #if USER_EXIT_OR_MENU
    //                    #endif//USER_EXIT_OR_MENU
    //
    //                b) #if USER_EXIT
    //                    #endif//USER_EXIT
    //        2) Create the Shared Library -- Refer "Block UI Styler programmer's guide"
    //        3) Invoke the Shared Library through File->Execute->NX Open menu.
    //
    //    3. THROUGH CALLBACK OF ANOTHER DIALOG
    //
    //        1) Remove the following conditional definition:
    //             #if CALLBACK
    //             #endif//CALLBACK
    //        2) Call the following line of code from where ever you want to lauch this dialog.
    //             dialogWith2Points.Show_dialogWith2Points();
    //        3) Integrate this file with your main application file.
    //
    //    4. MENU BAR
    //    
    //        1) Remove the following conditional definition:
    //                a) #if USER_EXIT_OR_MENU
    //                   #endif//USER_EXIT_OR_MENU
    //        2) Add the following lines to your MenuScript file in order to
    //           associate a menu bar button with your dialog.  In this
    //           example, a cascade menu will be created and will be
    //           located just before the Help button on the main menubar.
    //           The button, SAMPLEVB_BTN is set up to launch your dialog and
    //           will be positioned as the first button on your pulldown menu.
    //           If you wish to add the button to an existing cascade, simply
    //           add the 3 lines between MENU LAUNCH_CASCADE and END_OF_MENU
    //           to your menuscript file.
    //           The MenuScript file requires an extension of ".men".
    //           Move the contents between the dashed lines to your Menuscript file.
    //        
    //           !-----------------------------------------------------------------------------
    //           VERSION 120
    //        
    //           EDIT UG_GATEWAY_MAIN_MENUBAR
    //        
    //           BEFORE UG_HELP
    //           CASCADE_BUTTON BLOCKSTYLER_DLX_CASCADE_BTN
    //           LABEL Dialog Launcher
    //           END_OF_BEFORE
    //        
    //           MENU BLOCKSTYLER_DLX_CASCADE_BTN
    //           BUTTON SAMPLEVB_BTN
    //           LABEL Display SampleVB dialog
    //           ACTIONS <path of Shared library> !For example: D:\temp\SampleVB.dll
    //           END_OF_MENU
    //           !-----------------------------------------------------------------------------
    //        
    //        3) Make sure the .men file is in one of the following locations:
    //        
    //           - $UGII_USER_DIR/startup   
    //           - For released applications, using UGII_CUSTOM_DIRECTORY_FILE is highly
    //             recommended. This variable is set to a full directory path to a file 
    //             containing a list of root directories for all custom applications.
    //             e.g., UGII_CUSTOM_DIRECTORY_FILE=$UGII_ROOT_DIR\menus\custom_dirs.dat
    //    
    //------------------------------------------------------------------------------
//#if USER_EXIT_OR_MENU
    public static void Main()
    {
        try
        {
            thedialogWith2Points = new dialogWith2Points();
            // The following method shows the dialog immediately
            thedialogWith2Points.Show();
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        finally
        {
            thedialogWith2Points.Dispose();
        }
    }
//#endif//USER_EXIT_OR_MENU
//#if USER_EXIT
    //------------------------------------------------------------------------------
    // This method specifies how a shared image is unloaded from memory
    // within NX. This method gives you the capability to unload an
    // internal NX Open application or user  exit from NX. Specify any
    // one of the three constants as a return value to determine the type
    // of unload to perform:
    //
    //
    //    Immediately : unload the library as soon as the automation program has completed
    //    Explicitly  : unload the library from the "Unload Shared Image" dialog
    //    AtTermination : unload the library when the NX session terminates
    //
    //
    // NOTE:  A program which associates NX Open applications with the menubar
    // MUST NOT use this option since it will UNLOAD your NX Open application image
    // from the menubar.
    //------------------------------------------------------------------------------
     public static int GetUnloadOption(string arg)
    {
        //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
         return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
        // return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
    }
    
    //------------------------------------------------------------------------------
    // Following method cleanup any housekeeping chores that may be needed.
    // This method is automatically called by NX.
    //------------------------------------------------------------------------------
    public static int UnloadLibrary(string arg)
    {
        try
        {
            //---- Enter your code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return 0;
    }
//#endif//USER_EXIT
    
    //------------------------------------------------------------------------------
    //This method shows the dialog on the screen
    //------------------------------------------------------------------------------
    public NXOpen.UIStyler.DialogResponse Show()
    {
        try
        {
            theDialog.Show();
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return 0;
    }
    
    //------------------------------------------------------------------------------
    //Method Name: Dispose
    //------------------------------------------------------------------------------
    public void Dispose()
    {
        if(theDialog != null)
        {
            theDialog.Dispose();
            theDialog = null;
        }
    }
    
//#if CALLBACK
    //------------------------------------------------------------------------------
    //Method name: Show_dialogWith2Points
    //------------------------------------------------------------------------------
    public static void Show_dialogWith2Points()
    {
        try
        {
            thedialogWith2Points = new dialogWith2Points();
            // The following method shows the dialog immediately
            thedialogWith2Points.Show();
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        finally
        {
            thedialogWith2Points.Dispose();
        }
    }
//#endif//CALLBACK
    
    //------------------------------------------------------------------------------
    //---------------------Block UI Styler Callback Functions--------------------------
    //------------------------------------------------------------------------------
    
    //------------------------------------------------------------------------------
    //Callback Name: initialize_cb
    //------------------------------------------------------------------------------
    public void initialize_cb()
    {
        try
        {
            group02 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("group02");
            selection0 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("selection0");
            point0 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("point0");
            group0 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("group0");
            selection01 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("selection01");
            point1 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("point1");
            direction0 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("direction0");
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: dialogShown_cb
    //This callback is executed just before the dialog launch. Thus any value set 
    //here will take precedence and dialog will be launched showing that value. 
    //------------------------------------------------------------------------------
    public void dialogShown_cb()
    {
        try
        {
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: apply_cb
    //------------------------------------------------------------------------------
    public int apply_cb()
    {
        int errorCode = 0;
        try
        {
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            errorCode = 1;
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return errorCode;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: update_cb
    //------------------------------------------------------------------------------
    public int update_cb( NXOpen.BlockStyler.UIBlock block)
    {
        try
        {
            if (block == selection0)
            {





                PropertyList prop_list = block.GetProperties();
                TaggedObject[] tag_obs = prop_list.GetTaggedObjectVector("SelectedObjects");
                Component parentComponent = Config.findCompByBodyTag(tag_obs[0].Tag);

                //slotSet1 = new SlotSet(parentComponent);
                //slotSet1.setBottomFace();
                element1 = new UspElement(parentComponent);
                slotSet1 = new SlotSet(element1);
            }
            else if (block == point0)
            {
                slotSet1.setPoint(block);
                if (slotSet1.haveNearestBottomFace())
                {
                    
                }
            }
            else if (block == selection01)
            {
                PropertyList prop_list = block.GetProperties();
                TaggedObject[] tag_obs = prop_list.GetTaggedObjectVector("SelectedObjects");
                Component parentComponent = Config.findCompByBodyTag(tag_obs[0].Tag);

                element2 = new UspElement(parentComponent);
                slotSet2 = new SlotSet(element2);
                //slotSet2 = new SlotSet(parentComponent);
                //slotSet2.setBottomFace();

            }
            else if (block == point1)
            {
                slotSet2.setPoint(block);
                slotSet2.setNearestEdges();

                constr = new SlotConstraint();

                if (slotSet1.hasSlot(out slot1) && slotSet2.hasSlot(out slot2))
                {
                    constr.setEachOtherConstraint(slot1, slot2);
                }
                else
                {
                    Config.theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, "���(�) �� ��������");
                }
            }
            else if (block == direction0)
            {
                constr.removeTouch();
                constr.reverse();

                slot2.reverseTouchEdge();
                slot2.setTouchFace();
                constr.createSideTouch(slot1, slot2);
            }
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return 0;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: ok_cb
    //------------------------------------------------------------------------------
    public int ok_cb()
    {
        int errorCode = 0;
        try
        {
            errorCode = apply_cb();
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            errorCode = 1;
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return errorCode;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: cancel_cb
    //------------------------------------------------------------------------------
    public int cancel_cb()
    {
        try
        {
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return 0;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: filter_cb
    //------------------------------------------------------------------------------
    public int filter_cb(NXOpen.BlockStyler.UIBlock block, NXOpen.TaggedObject selectedObject)
    {
        return(NXOpen.UF.UFConstants.UF_UI_SEL_ACCEPT);
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: focusNotify_cb
    //This callback is executed when any block (except the ones which receive keyboard entry such as Integer block) receives focus.
    //------------------------------------------------------------------------------
    public void focusNotify_cb(NXOpen.BlockStyler.UIBlock block, bool focus)
    {
        try
        {
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: keyboardFocusNotify_cb
    //This callback is executed when block which can receive keyboard entry, receives the focus.
    //------------------------------------------------------------------------------
    public void keyboardFocusNotify_cb(NXOpen.BlockStyler.UIBlock block, bool focus)
    {
        try
        {
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
    
}

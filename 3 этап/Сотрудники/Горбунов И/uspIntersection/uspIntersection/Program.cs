﻿//==============================================================================
//  WARNING!!  This file is overwritten by the Block UI Styler while generating
//  the automation code. Any modifications to this file will be lost after
//  generating the code again.
//
//       Filename:  C:\ug_customization\application\dialogs\uspIntersection\inter.cs
//
//        This file was generated by the NX Block UI Styler
//        Created by: USP
//              Version: NX 7.5
//              Date: 05-23-2013  (Format: mm-dd-yyyy)
//              Time: 17:42 (Format: hh-mm)
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
using NXOpen.GeometricAnalysis;

//------------------------------------------------------------------------------
//Represents Block Styler application class
//------------------------------------------------------------------------------
public class UspIntersection
{
    //class members
    private static Session theSession = null;
    private static UI theUI = null;
    public static UspIntersection theInter;
    private string theDialogName;
    private NXOpen.BlockStyler.BlockDialog theDialog;
    private NXOpen.BlockStyler.UIBlock group0;// Block type: Group
    private NXOpen.BlockStyler.UIBlock selection1;// Block type: Selection
    private NXOpen.BlockStyler.UIBlock selection2;// Block type: Selection
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
    public static readonly int     SnapPointTypesOnByDefault_BoundedGridPoint = (1 <<16);
    
    //----------------------------------------------------------------------------------
    UspElement element1, element2;
    SlotSet slotSet1, slotSet2;
    bool firstSlotIsReady = false, secondSlotIsReady = false;


    //------------------------------------------------------------------------------
    //Constructor for NX Styler class
    //------------------------------------------------------------------------------
    public UspIntersection()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theDialogName = Config.dlxPath + Config.dlxName;
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
    //             inter.Show_inter();
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
            Log.writeLine("=======================================================" +
                Environment.NewLine + "Программа запущена!");

            theInter = new UspIntersection();
            // The following method shows the dialog immediately
            theInter.Show();
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        finally
        {
            theInter.Dispose();
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
    //Method name: Show_inter
    //------------------------------------------------------------------------------
    public static void Show_inter()
    {
        try
        {
            theInter = new UspIntersection();
            // The following method shows the dialog immediately
            theInter.Show();
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        finally
        {
            theInter.Dispose();
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
            group0 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("group0");
            selection1 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("selection1");
            selection2 = (NXOpen.BlockStyler.UIBlock)theDialog.TopBlock.FindBlock("selection2");
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
            Log.writeLine("Нажата кнопка 'Принять'.");
            this.showIntersection();
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
            if(block == selection1)
            {
            //---------Enter your code here-----------
                this.setFirstComponent(block);
            }
            else if(block == selection2)
            {
            //---------Enter your code here-----------
                this.setSecondComponent(block);
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
            Log.writeLine("Нажата кнопка 'ОК'.");
            this.showIntersection();
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
            Log.writeLine("Нажата кнопка 'Отмена'.");
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
    
    //------------------------------------------------------------------

    void setFirstComponent(UIBlock block)
    {
        Log.writeLine("Выбран объект по первому select.");
        this.setComponent(block, ref this.element1, ref this.slotSet1);
        this.firstSlotIsReady = false;
    }
    void setSecondComponent(UIBlock block)
    {
        Log.writeLine("Выбран объект по второму select.");
        this.setComponent(block, ref this.element2, ref this.slotSet2);
        this.secondSlotIsReady = false;
    }

    void setComponent(UIBlock block, ref UspElement element, ref SlotSet slotSet)
    {
        PropertyList prop_list = block.GetProperties();
        TaggedObject[] tag_obs = prop_list.GetTaggedObjectVector("SelectedObjects");

        Component parentComponent = Config.findCompByBodyTag(tag_obs[0].Tag);
        if (Geom.isComponent(tag_obs[0]))
        {
            Log.writeLine("Объект - " + tag_obs[0].ToString() +
                " - " + parentComponent.Name);

            element = new UspElement(parentComponent);
            slotSet = new SlotSet(element);
        }
        else
        {
            string message = "Выбрана не деталь УСП!" + Environment.NewLine +
                "Пожалуйста, перевыберите элемент.";
            Log.writeWarning(message);
            Config.theUI.NXMessageBox.Show("Error!",
                                           NXMessageBox.DialogType.Error,
                                           message);

            Log.writeLine("Объект - " + tag_obs[0].ToString() +
                " - " + parentComponent.Name);

            block.Focus();
        }
    }

    //------------------------------------------------------------------

    SimpleInterference.Result getIntersection(UspElement element1, UspElement element2)
    {
        SimpleInterference SI = Config.workPart.AnalysisManager.CreateSimpleInterferenceObject();

        SI.InterferenceType = SimpleInterference.InterferenceMethod.InterferingFaces;
        SI.FaceInterferenceType = SimpleInterference.FaceInterferenceMethod.AllPairs;

        SI.FirstBody.Value = element1.Body;
        SI.SecondBody.Value = element2.Body;

        SimpleInterference.Result result = SI.PerformCheck();
        Log.writeLine("Произведена проверка на пересечение элементов. Результат:" + 
                            Environment.NewLine + result.ToString());

        return result;
    }
    void showIntersection()
    {
        SimpleInterference.Result result = getIntersection(element1, element2);
        
        if (result == SimpleInterference.Result.CanNotPerformCheck)
        {
            Config.theUI.NXMessageBox.Show("Result", NXMessageBox.DialogType.Information, 
                        "Возникла неизвестная ошибка при вычислении пересечения!");
        }
        else if (result == SimpleInterference.Result.NoInterference)
        {
            Config.theUI.NXMessageBox.Show("Result", NXMessageBox.DialogType.Information,
                        "Пересечения не существует!");
        }
        else if (result == SimpleInterference.Result.OnlyEdgesOrFacesInterfere)
        {
            Config.theUI.NXMessageBox.Show("Result", NXMessageBox.DialogType.Information,
                        "Пересечение существует только по рёбрам и граням!");
        }
        else if (result == SimpleInterference.Result.InterferenceExists)
        {
            Config.theUI.NXMessageBox.Show("Result", NXMessageBox.DialogType.Information,
                        "Пересечение существует!");
        }
    }

}

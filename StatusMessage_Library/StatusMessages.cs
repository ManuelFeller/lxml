/*
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |  Status Message Class  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace DDPro.Software.Net20.Library
{
    /// <summary>Class for handling Messages on a ToolStrip-Label</summary>
    public class StatusMessages
    {

        #region Delegates and Events

        /// <summary>
        /// delegate for the LabelChangedEvent
        /// </summary>
        /// <param name="Data">List of Strings containing the File(s) that were changed</param>
        public delegate void LabelChangedEvent( LabelSettings Data );
        /// <summary>
        /// the NewMessage-Event - fired if there is new Status-Data to apply
        /// </summary>
        public event LabelChangedEvent NewMessage;

        #endregion

        #region public Enumerations and Structures

        /// <summary>
        /// The Message-Type for the Text to display
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// uses Default-Settings of Class (AutoDelete if activated)
            /// </summary>
            Default = 100,
            /// <summary>
            /// Message that must not be cleared by AutoDelete
            /// </summary>
            Static = 200,
            /// <summary>
            /// Message that should Flash (flashes defined number of cycles; the Message is static)
            /// </summary>
            Attention = 300,
            /// <summary>
            /// uses red as ForeColor; transparent BackColor (bold text)
            /// </summary>
            Red_ForeColor = 1000,
            /// <summary>
            /// uses red as BackColor; white as ForeColor (bold text)
            /// </summary>
            Red_BackColor = 1100,
            /// <summary>
            /// uses green as ForeColor; transparent BackColor (bold text)
            /// </summary>
            Green_ForeColor = 2000,
            /// <summary>
            /// uses green as BackColor; white as ForeColor (bold text)
            /// </summary>
            Green_BackColor = 2100
        }

        /// <summary>
        /// the Settings for the ToolStrip-Label
        /// </summary>
        public struct LabelSettings
        {
            /// <summary>
            /// the Message to Display
            /// </summary>
            public string Text;
            /// <summary>
            /// BackColor for the Label
            /// </summary>
            public System.Drawing.Color BackColor;
            /// <summary>
            /// ForeColor for the Label
            /// </summary>
            public System.Drawing.Color ForeColor;
            /// <summary>
            /// Font for the Label
            /// </summary>
            public System.Drawing.Font Font;
        }

        #endregion

        #region internal Fields and Objects

        /// <summary>
        /// the internal Field to remind the Label-Defaults
        /// </summary>
        private LabelSettings _int_LabelDefaults;

        /// <summary>
        /// internal Timer for Message-AutoDelete...
        /// </summary>
        private Timer _int_DelTimer;
        
        /// <summary>
        /// internal Field to remind usage of AutoDelete
        /// </summary>
        private bool _use_AutoDelete;
        
        /// <summary>
        /// internal Field to remind usage of AddTimestamp
        /// </summary>
        private bool _use_AddTimestamp;
        
        /// <summary>
        /// internal Field to save the Text to use as Timestamp-Separator
        /// </summary>
        private string _str_AddTimestampSeparator;

        #endregion

        #region public Constructors

        /// <summary>
        /// init a new instance
        /// </summary>
        public StatusMessages()
        {
            _int_LabelDefaults = new LabelSettings();
            _int_LabelDefaults.Text = "";
            _int_LabelDefaults.ForeColor = System.Drawing.Color.Black;
            _int_LabelDefaults.BackColor = System.Drawing.Color.Transparent;
            _int_LabelDefaults.Font = new System.Drawing.Font( "Tahoma", 10 );
            _init_clsStatusMessage();
        }

        /// <summary>
        /// init a new instance including label
        /// </summary>
        /// <param name="DefaultSettings">LabelSettings to use as default - Text is ignored</param>
        public StatusMessages( LabelSettings DefaultSettings )
        {
            _int_LabelDefaults = DefaultSettings;
            _init_clsStatusMessage();
        }

        #endregion

        #region public Properties

        /// <summary>
        /// get / set the default-settings for the Label
        /// </summary>
        public LabelSettings DefaultLabelSettings
        {
            get
            {
                return _int_LabelDefaults;
            }
            set
            {
                _int_LabelDefaults = value;
            }
        }
        
        /// <summary>
        /// get / set the AutoDelete-Option
        /// </summary>
        public bool AutoDelete
        {
            get
            {
                return _use_AutoDelete;
            }
            set
            {
                _use_AutoDelete = value;
                if( !value && _int_DelTimer.Enabled )
                {
                    _int_DelTimer.Enabled = false;
                }
            }
        }

        /// <summary>
        /// get / set the Time for AutoDelete of Messages
        /// </summary>
        public double AutoDeleteTime
        {
            get
            {
                return _int_DelTimer.Interval;
            }
            set
            {
                bool _restart = false;
                if( _int_DelTimer.Enabled ) // check if timer is running
                {
                    _int_DelTimer.Enabled = false; // stop
                    _restart = true; // remind restart
                }
                _int_DelTimer.Interval = value; // apply new value
                if( _restart ) // if needed
                {
                    _int_DelTimer.Enabled = true; // start timer again
                }
                
            }
        }

        /// <summary>
        /// get / set the AddTimestamp-Option
        /// </summary>
        public bool AddTimestamp
        {
            get
            {
                return _use_AddTimestamp;
            }
            set
            {
                _use_AddTimestamp = value;
            }
        }

        /// <summary>
        /// get / set the Text to use as Separator between Timestamp and Message
        /// </summary>
        public string AddTimestampSeparator
        {
            get
            {
                return _str_AddTimestampSeparator;
            }
            set
            {
                _str_AddTimestampSeparator = value;
            }
        }

        /// <summary>
        /// get the DLL-Version
        /// </summary>
        public System.Version DllVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        #endregion

        #region public Methods and Functions

        /// <summary>
        /// display a Message on the ToolStrip-Label
        /// </summary>
        /// <param name="Message">the Message to Display</param>
        public void DisplayMessage( string Message )
        {
            _DisplayMessage( Message, MessageType.Default, false );
        }

        /// <summary>
        /// display a Message on the ToolStrip-Label
        /// </summary>
        /// <param name="Message">the Message to Display</param>
        /// <param name="Parameter">the Message-Type to use</param>
        public void DisplayMessage( string Message , MessageType Parameter)
        {

            _DisplayMessage( Message, Parameter, false );
        }

        /// <summary>
        /// display a Message on the ToolStrip-Label
        /// </summary>
        /// <param name="Message">the Message to Display</param>
        /// <param name="Parameter">the Message-Type to use</param>
        /// <param name="NoTimestamp">set TRUE to supress the adding of the TimeStamp for this Message</param>
        public void DisplayMessage( string Message, MessageType Parameter, bool NoTimestamp )
        {
            _DisplayMessage( Message, Parameter, NoTimestamp );
        }

        #endregion

        #region internal worker

        /// <summary>
        /// internal init-method
        /// </summary>
        public void _init_clsStatusMessage()
        {
            // init internals
            _use_AutoDelete = false;
            _use_AddTimestamp = false;
            _str_AddTimestampSeparator = " | ";
            // create Timer
            _int_DelTimer = new Timer();
            _int_DelTimer.Enabled = false; // not active
            _int_DelTimer.Interval = 5000; // 5 seconds default
            // register event
            _int_DelTimer.Elapsed += new ElapsedEventHandler( onDeleteTimer );
        }

        /// <summary>
        /// Message-Display
        /// </summary>
        private void _DisplayMessage( string _Message, MessageType _Parameters, bool _NoTimestamp )
        {
            // stop Timer if needed
            if( _int_DelTimer.Enabled )
            {
                _int_DelTimer.Enabled = false;
            }
            // create Text for Label using StringBuilder
            StringBuilder _intMsg = new StringBuilder();
            // optional Timestamp
            if( _use_AddTimestamp && !_NoTimestamp )
            {
                _intMsg.Append( DateTime.Now.ToLongTimeString() + _str_AddTimestampSeparator );
            }
            // add message
            _intMsg.Append( _Message );

            // set LabelSettings
            LabelSettings _newSet = _FormatLabel( _Parameters ); // get predefined LabelSettings
            _newSet.Text = _intMsg.ToString(); // add text to object
            // FireEvent, DoEvents
            NewMessage( _newSet );
            System.Windows.Forms.Application.DoEvents();


            // if not static/attention and AutoDelete active, then start delete-timer
            if( _use_AutoDelete && ( _Parameters != MessageType.Attention && _Parameters != MessageType.Static ) )
            {
                _int_DelTimer.Enabled = true;
            }
            // ToDo: create Attention-Code here
        }

        /// <summary>
        /// define the Label-Format
        /// </summary>
        /// <param name="_Parameters">the Message-Type that should be used</param>
        /// <rreturns>new predefined LabelSettings with Empty Text</rreturns>
        private LabelSettings _FormatLabel( MessageType _Parameters )
        {
            LabelSettings _newSettings = new LabelSettings();
            _newSettings.Text = "";
            switch( _Parameters )
            {
                case MessageType.Green_BackColor:
                    _newSettings.ForeColor = System.Drawing.Color.White;
                    _newSettings.BackColor = System.Drawing.Color.Green;
                    _newSettings.Font = new System.Drawing.Font( _int_LabelDefaults.Font, System.Drawing.FontStyle.Bold );
                    break;
                case MessageType.Green_ForeColor:
                    _newSettings.ForeColor = System.Drawing.Color.Green;
                    _newSettings.BackColor = System.Drawing.Color.Transparent;
                    _newSettings.Font = new System.Drawing.Font( _int_LabelDefaults.Font, System.Drawing.FontStyle.Bold );
                    break;
                case MessageType.Red_BackColor:
                    _newSettings.ForeColor = System.Drawing.Color.White;
                    _newSettings.BackColor = System.Drawing.Color.Red;
                    _newSettings.Font = new System.Drawing.Font( _int_LabelDefaults.Font, System.Drawing.FontStyle.Bold );
                    break;
                case MessageType.Red_ForeColor:
                    _newSettings.ForeColor = System.Drawing.Color.Red;
                    _newSettings.BackColor = System.Drawing.Color.Transparent;
                    _newSettings.Font = new System.Drawing.Font( _int_LabelDefaults.Font, System.Drawing.FontStyle.Bold );
                    break;
                default: // regular color-setting
                    _newSettings.ForeColor = _int_LabelDefaults.ForeColor;
                    _newSettings.BackColor = _int_LabelDefaults.BackColor;
                    _newSettings.Font = _int_LabelDefaults.Font;
                    break;
            }
            return _newSettings;
        }

        /// <summary>
        /// Worker for the Delete-Timer
        /// </summary>
        private void onDeleteTimer( Object sender, ElapsedEventArgs e )
        {
            // stop delete-timer
            _int_DelTimer.Enabled = false;
            // set LabelSettings
            LabelSettings _newSet = _FormatLabel(MessageType.Static); // get predefined LabelSettings
            // FireEvent, DoEvents
            NewMessage( _newSet );
            System.Windows.Forms.Application.DoEvents();


        }

        #endregion
    }
}
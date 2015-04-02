﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFCallbacks
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "User", Namespace = "http://schemas.datacontract.org/2004/07/WCFCallbacks", IsReference = true)]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string EmailField;

        private WCFCallbacks.Friend[] FriendsField;

        private WCFCallbacks.Friend[] Friends1Field;

        private WCFCallbacks.Message[] MessagesField;

        private WCFCallbacks.Message[] Messages1Field;

        private string NameField;

        private string PasswordField;

        private string PhoneField;

        private string SurnameField;

        private int UserIdField;

        private string UserNameField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.Friend[] Friends
        {
            get
            {
                return this.FriendsField;
            }
            set
            {
                this.FriendsField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.Friend[] Friends1
        {
            get
            {
                return this.Friends1Field;
            }
            set
            {
                this.Friends1Field = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.Message[] Messages
        {
            get
            {
                return this.MessagesField;
            }
            set
            {
                this.MessagesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.Message[] Messages1
        {
            get
            {
                return this.Messages1Field;
            }
            set
            {
                this.Messages1Field = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone
        {
            get
            {
                return this.PhoneField;
            }
            set
            {
                this.PhoneField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname
        {
            get
            {
                return this.SurnameField;
            }
            set
            {
                this.SurnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId
        {
            get
            {
                return this.UserIdField;
            }
            set
            {
                this.UserIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this.UserNameField;
            }
            set
            {
                this.UserNameField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Friend", Namespace = "http://schemas.datacontract.org/2004/07/WCFCallbacks", IsReference = true)]
    public partial class Friend : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int FriendIdField;

        private int IdField;

        private WCFCallbacks.User UserField;

        private WCFCallbacks.User User1Field;

        private int UserIdField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FriendId
        {
            get
            {
                return this.FriendIdField;
            }
            set
            {
                this.FriendIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.User User
        {
            get
            {
                return this.UserField;
            }
            set
            {
                this.UserField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.User User1
        {
            get
            {
                return this.User1Field;
            }
            set
            {
                this.User1Field = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId
        {
            get
            {
                return this.UserIdField;
            }
            set
            {
                this.UserIdField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Message", Namespace = "http://schemas.datacontract.org/2004/07/WCFCallbacks", IsReference = true)]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private System.DateTime DateField;

        private int FromUserField;

        private int MessageIdField;

        private string TextField;

        private int ToUserField;

        private WCFCallbacks.User UserField;

        private WCFCallbacks.User User1Field;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date
        {
            get
            {
                return this.DateField;
            }
            set
            {
                this.DateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FromUser
        {
            get
            {
                return this.FromUserField;
            }
            set
            {
                this.FromUserField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MessageId
        {
            get
            {
                return this.MessageIdField;
            }
            set
            {
                this.MessageIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this.TextField;
            }
            set
            {
                this.TextField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToUser
        {
            get
            {
                return this.ToUserField;
            }
            set
            {
                this.ToUserField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.User User
        {
            get
            {
                return this.UserField;
            }
            set
            {
                this.UserField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFCallbacks.User User1
        {
            get
            {
                return this.User1Field;
            }
            set
            {
                this.User1Field = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IMessage", CallbackContract = typeof(IMessageCallback))]
public interface IMessage
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/AddMessage", ReplyAction = "http://tempuri.org/IMessage/AddMessageResponse")]
    void AddMessage(string message);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/AddMessage", ReplyAction = "http://tempuri.org/IMessage/AddMessageResponse")]
    System.Threading.Tasks.Task AddMessageAsync(string message);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Subscribe", ReplyAction = "http://tempuri.org/IMessage/SubscribeResponse")]
    bool Subscribe(int id);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Subscribe", ReplyAction = "http://tempuri.org/IMessage/SubscribeResponse")]
    System.Threading.Tasks.Task<bool> SubscribeAsync(int id);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Unsubscribe", ReplyAction = "http://tempuri.org/IMessage/UnsubscribeResponse")]
    bool Unsubscribe();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Unsubscribe", ReplyAction = "http://tempuri.org/IMessage/UnsubscribeResponse")]
    System.Threading.Tasks.Task<bool> UnsubscribeAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/GetFriendList", ReplyAction = "http://tempuri.org/IMessage/GetFriendListResponse")]
    WCFCallbacks.User[] GetFriendList(int userId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/GetFriendList", ReplyAction = "http://tempuri.org/IMessage/GetFriendListResponse")]
    System.Threading.Tasks.Task<WCFCallbacks.User[]> GetFriendListAsync(int userId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Test", ReplyAction = "http://tempuri.org/IMessage/TestResponse")]
    string Test();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Test", ReplyAction = "http://tempuri.org/IMessage/TestResponse")]
    System.Threading.Tasks.Task<string> TestAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/LogIn", ReplyAction = "http://tempuri.org/IMessage/LogInResponse")]
    int LogIn(string username, string password);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/LogIn", ReplyAction = "http://tempuri.org/IMessage/LogInResponse")]
    System.Threading.Tasks.Task<int> LogInAsync(string username, string password);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Register", ReplyAction = "http://tempuri.org/IMessage/RegisterResponse")]
    int Register(string name, string surname, string email, string phone, string username, string password);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/Register", ReplyAction = "http://tempuri.org/IMessage/RegisterResponse")]
    System.Threading.Tasks.Task<int> RegisterAsync(string name, string surname, string email, string phone, string username, string password);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/SendMessage", ReplyAction = "http://tempuri.org/IMessage/SendMessageResponse")]
    void SendMessage(int from, int to, string message);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/SendMessage", ReplyAction = "http://tempuri.org/IMessage/SendMessageResponse")]
    System.Threading.Tasks.Task SendMessageAsync(int from, int to, string message);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/GetMessages", ReplyAction = "http://tempuri.org/IMessage/GetMessagesResponse")]
    WCFCallbacks.Message[] GetMessages(int userId, int friendId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/GetMessages", ReplyAction = "http://tempuri.org/IMessage/GetMessagesResponse")]
    System.Threading.Tasks.Task<WCFCallbacks.Message[]> GetMessagesAsync(int userId, int friendId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/AddFriend", ReplyAction = "http://tempuri.org/IMessage/AddFriendResponse")]
    void AddFriend(int userId, int friendId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/AddFriend", ReplyAction = "http://tempuri.org/IMessage/AddFriendResponse")]
    System.Threading.Tasks.Task AddFriendAsync(int userId, int friendId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/LogOut", ReplyAction = "http://tempuri.org/IMessage/LogOutResponse")]
    void LogOut(int userId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMessage/LogOut", ReplyAction = "http://tempuri.org/IMessage/LogOutResponse")]
    System.Threading.Tasks.Task LogOutAsync(int userId);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IMessageCallback
{

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IMessage/OnMessageAdded")]
    void OnMessageAdded(string message, System.DateTime timestamp);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IMessage/OnFriendConnected")]
    void OnFriendConnected(int friendId, System.DateTime timestamp);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IMessage/OnFriendDisconnected")]
    void OnFriendDisconnected(int friendId, System.DateTime timestamp);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IMessage/OnMessageSent")]
    void OnMessageSent(int from, int to, string message, System.DateTime timestamp);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IMessageChannel : IMessage, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MessageClient : System.ServiceModel.DuplexClientBase<IMessage>, IMessage
{

    public MessageClient(System.ServiceModel.InstanceContext callbackInstance) :
        base(callbackInstance)
    {
    }

    public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
        base(callbackInstance, endpointConfigurationName)
    {
    }

    public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
        base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public MessageClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(callbackInstance, binding, remoteAddress)
    {
    }

    public void AddMessage(string message)
    {
        base.Channel.AddMessage(message);
    }

    public System.Threading.Tasks.Task AddMessageAsync(string message)
    {
        return base.Channel.AddMessageAsync(message);
    }

    public bool Subscribe(int id)
    {
        return base.Channel.Subscribe(id);
    }

    public System.Threading.Tasks.Task<bool> SubscribeAsync(int id)
    {
        return base.Channel.SubscribeAsync(id);
    }

    public bool Unsubscribe()
    {
        return base.Channel.Unsubscribe();
    }

    public System.Threading.Tasks.Task<bool> UnsubscribeAsync()
    {
        return base.Channel.UnsubscribeAsync();
    }

    public WCFCallbacks.User[] GetFriendList(int userId)
    {
        return base.Channel.GetFriendList(userId);
    }

    public System.Threading.Tasks.Task<WCFCallbacks.User[]> GetFriendListAsync(int userId)
    {
        return base.Channel.GetFriendListAsync(userId);
    }

    public string Test()
    {
        return base.Channel.Test();
    }

    public System.Threading.Tasks.Task<string> TestAsync()
    {
        return base.Channel.TestAsync();
    }

    public int LogIn(string username, string password)
    {
        return base.Channel.LogIn(username, password);
    }

    public System.Threading.Tasks.Task<int> LogInAsync(string username, string password)
    {
        return base.Channel.LogInAsync(username, password);
    }

    public int Register(string name, string surname, string email, string phone, string username, string password)
    {
        return base.Channel.Register(name, surname, email, phone, username, password);
    }

    public System.Threading.Tasks.Task<int> RegisterAsync(string name, string surname, string email, string phone, string username, string password)
    {
        return base.Channel.RegisterAsync(name, surname, email, phone, username, password);
    }

    public void SendMessage(int from, int to, string message)
    {
        base.Channel.SendMessage(from, to, message);
    }

    public System.Threading.Tasks.Task SendMessageAsync(int from, int to, string message)
    {
        return base.Channel.SendMessageAsync(from, to, message);
    }

    public WCFCallbacks.Message[] GetMessages(int userId, int friendId)
    {
        return base.Channel.GetMessages(userId, friendId);
    }

    public System.Threading.Tasks.Task<WCFCallbacks.Message[]> GetMessagesAsync(int userId, int friendId)
    {
        return base.Channel.GetMessagesAsync(userId, friendId);
    }

    public void AddFriend(int userId, int friendId)
    {
        base.Channel.AddFriend(userId, friendId);
    }

    public System.Threading.Tasks.Task AddFriendAsync(int userId, int friendId)
    {
        return base.Channel.AddFriendAsync(userId, friendId);
    }

    public void LogOut(int userId)
    {
        base.Channel.LogOut(userId);
    }

    public System.Threading.Tasks.Task LogOutAsync(int userId)
    {
        return base.Channel.LogOutAsync(userId);
    }
}

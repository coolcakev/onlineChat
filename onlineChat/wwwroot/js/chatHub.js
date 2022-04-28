
class  ChatHub {
    static hubConnection;
    static async makeConnection(route) {
        ChatHub.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(route)
            .build();

       await ChatHub.hubConnection.start();
    }
    static setFunctionEventGetConnetctedId(functionEvent) {

        ChatHub.hubConnection.on("GetConnetctedId", functionEvent);
    }
    static invokeFunctionJoinGroup(groupId) {

        ChatHub.hubConnection.invoke("JoinGroup", groupId);
    }
    static invokeFunctionJoinGroupMyFriend(groupId,connectionId) {

        ChatHub.hubConnection.invoke("JoinGroupMyFriend", groupId, connectionId);
    }
    static invokeFunctionJoinManyGroup(groupsId) {

        ChatHub.hubConnection.invoke("JoinManyGroup", groupsId);
    }
    static invokeFunctionSendMessage(chatId,message,user) {

        ChatHub.hubConnection.invoke("SendMessage",chatId, message, user);
    }
    static setFunctionEvenSendMessage(functionEvent) {

        ChatHub.hubConnection.on("SendMessage", functionEvent);
    }
    static setFunctionEvenSendChat(functionEvent) {

        ChatHub.hubConnection.on("SendChat", functionEvent);
    }
    static invokeFunctionEvenSendChat(chat,placeForChatId) {

        ChatHub.hubConnection.invoke("SendChat", chat, placeForChatId);
    } 

}

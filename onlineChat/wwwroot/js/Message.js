console.log("_Message")
function joinMyFriendToChat(chat, connectionUserId) {
    let model = {
        ChatId: chat.id,
        UserName: chat.title,
        UserConnectionId: connectionUserId,
    }
    
    ChatHub.invokeFunctionJoinGroupMyFriend(chat.id.toString(), connectionUserId)
    ApiMessage.joinUser(model, chat)
}
function apiCreateChatSuccess(chat, connectionUserId) {
    let placeForChatSelector = "Friends";
    joinChat(chat)
    joinMyFriendToChat(chat, connectionUserId)
    ChatHub.invokeFunctionEvenSendChat(chat, placeForChatSelector)
}
function sendMessageToFriend(model) {    
    let chatTitle = model.userName
    let userConnectionId = model.userConnectionId
    let typeChatEnum = typeChat.Chat
    ApiMessage.CreateChat(chatTitle, typeChatEnum, (chat) => apiCreateChatSuccess(chat, userConnectionId))
}

class ApiMessage {
    static GetMessege(chatId) {
        $.ajax({
            type: "GET",
            url: `/Chat/GetMessages?chatId=${chatId}`,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                let allChatsElement = document.getElementById("PlaceForMessage")
                allChatsElement.innerHTML = data;
            }
        });

    }
    static CreateChat(chatTitle, typeChat, functionSuccsess) {
        var model = {
            Title: chatTitle,
            Type: typeChat
        }
        $.ajax({
            type: "Post",
            url: `/Chat/Create`,
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            success: function (data) {               
                functionSuccsess(data)               
            }
        });
    }
    static joinUser(model,chat) {
        $.ajax({
            type: "Post",
            url: `/Chat/JoinUser`,
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            success: function () {               
                ApiMessage.GetMessege(chat.id)
            }
        });
    }
    

}


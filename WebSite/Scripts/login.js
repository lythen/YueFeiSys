//验证是否登陆
function checkLogin(data) {
    if (data == "nologin") {
        alert("没有登陆或登陆超时，请重新登陆。");
        top.location.href = "login.html";
        return false;
    }
    return true;
}
//获取JSON
function synchroAjaxByUrl(url) {
    var temp;
    $.ajax({
        url: url,
        type: "get",
        async: false,
        dataType: "json",
        success: function (data) {
            temp = data;
        }
    });
    return temp;
}
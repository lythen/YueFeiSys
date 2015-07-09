function checkLogin(data) {
    if (data == "nologin") {
        alert("没有登陆或登陆超时，请重新登陆。");
        top.location.href = "login.html";
        return false;
    }
    return true;
}
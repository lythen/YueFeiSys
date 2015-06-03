/***********************************************************************
* 判斷一個字符串是否是數值格式
*/
function isNumber(numStr) {
    if (numStr == "") return false;
    return !isNaN(numStr);
}
/***********************************************************************
* 判斷一個字符串中是否含有下列非法字符
*/
voidChar = "'\"><";
function isValidString(szStr) {
    for (i = 0; i < voidChar.length; i++) {
        aChar = voidChar.substring(i, i + 1);
        if (szStr.indexOf(aChar) > -1) {
            return true;
        }
    }
    return false;
}
/***********************************************************************
* 判斷一個字符串是否爲空字符串
*/
function isBlank(szStr) {
    if (szStr.length < 1) {
        return true;
    }
    for (i = 0; i < szStr.length; i++) {
        if (szStr.substring(i, i + 1) != ' ') {
            return false;
        }
    }
    return true;
}
/***********************************************************************
* 去掉一個字符串兩端的空格
*/
function trim(szStr) {
    //去掉字符串頭部的空格
    while (szStr.length > 0) {
        if (szStr.substring(0, 1) != ' ') {
            break;
        } else {
            szStr = szStr.substring(1);
        }
    }
    //去掉字符串尾部的空格
    while (szStr.length > 0) {
        if (szStr.substring(szStr.length - 1, szStr.length) != ' ') {
            break;
        } else {
            szStr = szStr.substring(0, szStr.length - 1);
        }
    }
    return szStr;
}
/***********************************************************************
* 判斷一個字符串是否爲合法的日期格式：YYYY-MM-DD HH:MM:SS
* 或 YYYY-MM-DD 或 HH:MM:SS
*/
function isDateStr(ds) {
    parts = ds.split(' ');
    switch (parts.length) {
        case 2:
            if (isDatePart(parts[0]) == true && isTimePart(parts[1])) {
                return true;
            } else {
                return false;
            }
        case 1:
            aPart = parts[0];
            if (aPart.indexOf(':') > 0) {
                return isTimePart(aPart);
            } else {
                return isDatePart(aPart);
            }
        default:
            return false;
    }
}
/***********************************************************************
* 判斷一個字符串是否爲合法的日期格式：YYYY-MM-DD
*/
function isDatePart(dateStr) {
    var parts;
    if (dateStr.indexOf("-") > -1) {
        parts = dateStr.split('-');
    } else if (dateStr.indexOf("/") > -1) {
        parts = dateStr.split('/');
    } else {
        return false;
    }
    if (parts.length < 3) {
        //日期部分不允許缺少年、月、日中的任何一項
        return false;
    }
    for (i = 0; i < 3; i++) {
        //如果構成日期的某個部分不是數字，則返回false
        if (isNaN(parts[i])) {
            return false;
        }
    }
    y = parts[0]; //年
    m = parts[1]; //月
    d = parts[2]; //日
    if (y > 3000) {
        return false;
    }
    if (m < 1 || m > 12) {
        return false;
    }
    switch (d) {
        case 29:
            if (m == 2) {
                //如果是2月份
                if ((y / 100) * 100 == y && (y / 400) * 400 != y) {
                    //如果年份能被100整除但不能被400整除 (即閏年)
                } else {
                    return false;
                }
            }
            break;
        case 30:
            if (m == 2) {
                //2月沒有30日
                return false;
            }
            break;
        case 31:
            if (m == 2 || m == 4 || m == 6 || m == 9 || m == 11) {
                //2、4、6、9、11月沒有31日
                return false;
            }
            break;
        default:
    }
    return true;
}
/***********************************************************************
* 判斷一個字符串是否爲合法的時間格式：HH:MM:SS
*/
function isTimePart(timeStr) {
    var parts;
    parts = timeStr.split(':');
    if (parts.length < 2) {
        //日期部分不允許缺少小時、分鐘中的任何一項
        return false;
    }
    for (i = 0; i < parts.length; i++) {
        //如果構成時間的某個部分不是數字，則返回false
        if (isNaN(parts[i])) {
            return false;
        }
    }
    h = parts[0]; //年
    m = parts[1]; //月
    if (h < 0 || h > 23) {
        //限制小時的範圍
        return false;
    }
    if (m < 0 || h > 59) {
        //限制分鐘的範圍
        return false;
    }
    if (parts.length > 2) {
        s = parts[2]; //日
        if (s < 0 || s > 59) {
            //限制秒的範圍
            return false;
        }
    }
    return true;
}
function chk_email(email) {
    invalid = "";
    if (!email) { }
    //invalid = "請輸入您的Email地址。";
    else {
        if ((email.indexOf("@") == -1) || (email.indexOf(".") == -1))
            invalid += "\n\nEmail地址不合法。應當包含[email='@']%27@%27[/email]和'.'；例如('.com')。請檢查後再遞交。";
        if (email.indexOf("your email here") > -1)
            invalid += "\n\nEmail地址不合法，請檢測您的Email地址，在域名內應當包含[email='@']%27@%27[/email]和'.'；例如('.com')。";
        if (email.indexOf("\\") > -1)
            invalid += "\n\nEmail地址不合法，含有非法字符(\\)。";
        if (email.indexOf("/") > -1)
            invalid += "\n\nEmail地址不合法，含有非法字符(/)。";
        if (email.indexOf("'") > -1)
            invalid += "\n\nEmail地址不合法，含有非法字符(')。";
        if (email.indexOf("!") > -1)
            invalid += "\n\nEmail地址不合法，含有非法字符(!)。";
        if ((email.indexOf(",") > -1) || (email.indexOf(";") > -1))
            invalid += "\n\n只輸入一個Email地址，不要含有分號和逗號。";
        if (email.indexOf("?subject") > -1)
            invalid += "\n\n不要加入'?subject=...'。";
    }
    if (invalid == "") {
        return true;
    } else {
        alert("輸入的Email可能包含錯誤：" + invalid);
        return false;
    }
}
//精確判斷字符串長度

function isChinese(str) {
    var lst = /[u00-uFF]/;
    return !lst.test(str);
}
function strlen(str) {
    var strlength = 0;
    for (i = 0; i < str.length; i++) {
        if (isChinese(str.charAt(i)) == true)
            strlength = strlength + 2;
        else
            strlength = strlength + 1;
    }
    return strlength;
}

//判斷字符串中是否存在空格
function isKong(szStr) {
    //trim方法爲上面去掉字符串首尾空格的方法，不是系統方法
    var str = trim(szStr);
    if (strlen(str) > 0) {
        if (str.indexOf(' ') >= 0) {
            return true;
        }
    }
    return false;
}
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
function checkisPhone(s) {
    if (!isTel(s) && !isMobile(s)) {
            return false;
    }
    return true;
}

//校验普通电话、传真号码：可以“+”开头，除数字外，可含有“-”
function isTel(s) {
    //国家代码(2到3位)-区号(2到3位)-电话号码(7到8位)-分机号(3位)"

    var pattern = /^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;
    //var pattern =/(^[0-9]{3,4}\-[0-9]{7,8}$)|(^[0-9]{7,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)/;
    if (s != "") {
        if (!pattern.exec(s)) {
            return false;
        } else return true;
    } else return false;
}
//校验手机号码：必须以数字开头，除数字外，可含有“-”
function isMobile(s) {
    var reg0 = /^13\d{5,9}$/;
    var reg1 = /^153\d{4,8}$/;
    var reg2 = /^159\d{4,8}$/;
    var reg3 = /^0\d{10,11}$/;
    var my = false;
    if (reg0.test(s)) my = true;
    if (reg1.test(s)) my = true;
    if (reg2.test(s)) my = true;
    if (reg3.test(s)) my = true;
    if (s != "") {
        if (!my) {
            return false;
        } else return true;
    } else return false;
}
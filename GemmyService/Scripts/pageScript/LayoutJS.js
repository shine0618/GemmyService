

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) { return c.substring(name.length, c.length); }
    }
    return "";
}
function checkCookie() {
    var user = getCookie("username");

}



//获取语言
function GetLanguCode() {

    // var CustomLang = '@Session["PageLanguage"].ToString()';
    //如果客户语言
    //if (CustomLang == 'default') {
    //    var lang = navigator.language || navigator.userLanguage;//常规浏览器语言和IE浏览器
    //    lang = lang.substr(0, 2);//截取lang前2位字符
    //    return lang;
    //}
    //else {
    //    return CustomLang;
    //}

    //方法2
    var lang = navigator.language || navigator.userLanguage;//常规浏览器语言和IE浏览器
    lang = lang.substr(0, 2);//截取lang前2位字符

    var rtlang = lang;
    $.ajax({
        type: 'GET',
        url: "/JCSelectionLanguage/GetLanguagesDetail",
        async: false,
        data: {
            keys: '123',
            code: '',
            pagecode: lang,
        },
        contentType: "application/json",
        dataType: 'json',
        success: function (result) {
        //    console.log(result)
            rtlang =  result.LanguageCode;
        },
        error: function (err) {
        },
    });


    return rtlang;
    //this.$http({           //调用接口
    //    method: 'GET',
    //    url: "/JCSelectionLanguage/GetLanguagesDetail",
    //    params: {
    //        keys: '123',
    //        code: '',
    //        pagecode: lang,
    //    }
    //}).then(function (response) {  //接口返回数据
    //    return response.body.LanguageCode;
    //}, function (error) {
    //    return lang;
    //    console.log(error);
    //})



}

//获取已经登录的用户名
function GetLoginUsername() {

    var rtlang = "";
    $.ajax({
        type: 'GET',
        url: "/JCAccount/GetUserNameName",
        async: false,
        data: {
            keys: '123',
        },
        contentType: "application/json",
        dataType: 'text',
        success: function (result) {
            //    console.log(result)
            rtlang = result;
        },
        error: function (err) {
        },
    });


    return rtlang;

}



function downloadPDF(shouldDownload, $table, pdfName) {
    shouldDownload = shouldDownload || false;    // 预览还是导出
    var doc = new jsPDF('p', 'pt');          // 初始化示例，更多配置项看官网api
    doc.text("From HTML", 40, 50);           // 表title、距离左边距离、距离上边距离
    var res = doc.autoTableHtmlToJson($table);        // 获取当前表格的数据
    doc.autoTable(res.columns, res.data, { startY: 60 });    // 渲染数据，列、数据、距离上边距离，更多配置项看官网api

    if (shouldDownload) {
        doc.save(pdfName + '.pdf');    // 导出名为tableName.pdf的文件
    } else {
        // doc.output('datauristring')：pdf预览的地址，一段base64地址
        document.getElementById("output").src = doc.output('datauristring');
    }
}


//构造二维码
function initQRCode(divid, qrvalue) {
    var qrcode = new QRCode(document.getElementById(divid), {
        text: qrvalue,
        width: 128,
        height: 128,
        colorDark: "#000000",
        colorLight: "#ffffff",
        correctLevel: 0 // 二维码结构复杂性 0~3
    });
}
var domain = GetDeskdomain();
var type = GetDeskType();
var recommend = GetDeskrecommend();
var name = GetDeskproductName();
var guid = GetDeskproductGuid();
console.log(name);
var OfficeStandards = new Vue({
    el: '#OfficeStandards',
    data: {
        isAble: false,
        options: [{
            value: 'DXF2D',
            label: 'DXF2D'
        },
        {
            value: 'CREO5',
            label: 'CREO5'
        },
        {
            value: 'SOLIDWORKS',
            label: 'SOLIDWORKS'
        },
        {
            value: 'DWG2D',
            label: 'DWG2D'
        },
        {
            value: 'PDFDATASHEET',
            label: 'PDF'
        },
        {
            value: '3DSTUDIOMAX',
            label: '3DS'
        },
        {
            value: 'STEP-2.14',
            label: 'STEP'
        },
        {
            value: 'OBJFILE',
            label: 'OBJ'
        }],
        loading: false,
        MainAllowNotice:'',
        username: '',
        filename: '',
        format: '',
        OrderValue: "",
        Order: 0,//1正序 2倒序
        domain: domain,
        Type: type,
        recommend: recommend,
        langCode: "",                     
        deskList: null,
        activeName: 'd2',
        productName: name,
        productGuid: guid,
        deskSerialName: '',
        T_Product_office_desk: null,
        T_Product_office_desk_detail: null,
        descriptions: null,//关键参数
        configurationNo: "",
        introduction: "",
        modelurl: '',
        list_Color: [],
        select_Color: '',
        oldcolor: '',
        //文件
        files_d1: [],
        isCollect: false,
        //尺寸图
        files_d2_2D: [],
        files_d2_3D: [],
        //认证
        files_d3: [],

        //文件资料
        files_d4: [],

        //text
        text_detail_1: "",
        text_detail_2: "",
        text_detail_3: "",
        text_detail_4: "",
        text_detail_5: "",
        text_detail_6: "",
        text_detail_7: "",
        text_detail_8: "",
        text_detail_9: "",
        text_detail_10: "",
        text_detail_11: "",
        text_detail_12: "",
        text_detail_13: "",
        text_detail_14: "",
        text_detail_15: "",
        text_detail_16: "",
        text_detail_17: "",
        text_detail_18: "",
        MyCollectName: "",
        paramTableData: [],
        NAVMainPage: "",
        NAVOfficePage: "",
        NAVProductDetailPage: "",
        ProductConfigurationList: "",
        ProductConfigurationCustomButton: "",
        ProductExportConfigurationButton: "",
        ProductFilesAndDesc: "",
        ProductDownloadButton: "",
        ProductCollectSuccess: "",
        ProductCollectFail: "",
        ProductCollectCancelSuccess: "",
        ProductCollectCancelFail: "",
        ProductDetailLength: "",
        ProductDetailLoad: "",
        ProductDetailSpeed: "",
        Downloadlabel: "",
        Downloadbutton: "",
        DownloadNoRight: '',
        DownloadChooseOneType:'',
    },
    //watch: {
    //    OrderValue: function (val) {
    //        this.getallDesk();
    //    },
    //    Order: function (val) {
    //        this.getallDesk();
    //    }
    //},
    mounted() {
        window.setloadingjs = this.setloading
    },
    methods: {
        handleClick(tab, event) {

        },
        GetfileName: function (fname, type) {
            //if (fname == "") {

            //    var str = type;
            //    if (str.indexOf("doc") != '-1');
            //    {
            //        return "/resourse/Img/word_icon.png";
            //    }
            //    if (str.indexOf("xls") != '-1');
            //    {
            //        return "/resourse/Img/excel_icon.png";
            //    }
            //     return "/resourse/Img/pdf_icon.png";
            //}

            //  console.log(fname);
            return fname;
        },
        CollectDesk: function () {
            this.$http({           //调用接口
                method: 'POST',
                url: "/JCSelection/CollectDesk",
                params: {
                    deskId: this.T_Product_office_desk.Id,
                }
            }).then(function (response) {  //接口返回数据
                if (response.body > 0) {
                    this.$notify({
                        message: this.ProductCollectSuccess,
                        type: 'success'
                    });
                    this.isCollect = true;
                }
                else {
                    this.$notify.error(this.ProductCollectFail);
                    this.isCollect = false;
                }
            }, function (error) {
                //console.log(error);
            })
        },
        CancelCollectDesk: function () {
            this.$http({           //调用接口
                method: 'POST',
                url: "/JCSelection/CancelCollectDesk",
                params: {
                    deskId: this.T_Product_office_desk.Id,
                }
            }).then(function (response) {  //接口返回数据
                if (response.body > 0) {
                    this.$notify({
                        message: this.ProductCollectCancelSuccess,
                        type: 'success'
                    });
                    this.isCollect = false;
                }
                else {
                    this.$notify.error(this.ProductCollectCancelFail);
                    this.isCollect = true;
                }
            }, function (error) {
                //console.log(error);
            })
        },



        exportConfig: function (event) {

            var doc = new jsPDF('p', 'pt');          // 初始化示例，更多配置项看官网api

            //doc.addFont('msyh.ttf', 'msyh', 'normal');
            doc.setFont('msyh');
            doc.text("JIECANG Office Configuration", 40, 50);           // 表title、距离左边距离、距离上边距离
            var res = doc.autoTableHtmlToJson(document.getElementById("paramTB"));
            // console.log(res);
            doc.autoTable(res.columns, res.data, { startY: 60 });    // 渲染数据，列、数据、距离上边距离，更多配置项看官网api

            doc.save('tableName.pdf');    // 导出名为tableName.pdf的文件

        },
        downloadfile: function (url, fname, type) {

            if (type == ".dwg" || type == ".stp") {
                fname = fname + type;
            }


            // console.log(url);
            //window.open(url);   //该方法只能下载比如xls等不能直接打开的文件，对于png之类的文件会直接打开而非下载

            const link = document.createElement('a');
            link.style.display = 'none';
            link.href = url;
            link.setAttribute('download', fname);
            document.body.appendChild(link);
            link.click();
        },
        gotoCustmer: function (event) {
            window.location = "/JCSelection/office_Eservice_test?domain=" + this.domain + "&Type=" + this.Type + "&recommend=" + this.recommend + "&productName=" + this.productName + "&productGuid=" + this.productGuid;
        },
        initPage: function (event) {
            var code = GetLanguCode();
            this.langCode = code;
            this.username = GetLoginUsername();
            $.ajaxSettings.async = false;
            var languText;
            $.getJSON("/resourse/Language/text-" + code + ".json", function (result) {
                languText = result.language;
            });
            $.ajaxSettings.async = true;
            var obj = languText;
            for (var p in obj) {
                // 方法
                if (typeof (obj[p]) == "function") {
                    obj[p]();
                } else {
                    // p 为属性名称，obj[p]为对应属性的值
                    var key = p;
                    var value = obj[p];
                    // console.log('key:' + key + "  value:" + value);
                    this.setData(key, value);;
                }
            }


        },
        getThisDesk: function (event) {
            //文件列表
            //var fitem = { filethumbnail: '/resourse/office/fileimg.png', fileName: 'VUE的和CBD6S使用手册可下载pdf', fileDes: '本使用手册将会告诉您如何安装,使用并维护您的产品' };
            //this.files_d1.push(fitem);


            //获取桌子详细信息
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/GetOfficeDeskDetail",
                params: {
                    lang: this.langCode,
                    productGuid: this.productGuid,

                }
            }).then(function (response) {  //接口返回数据

                var column = "";
                var frame = "";
                var foot = "";
                var control = "";
                var handset = "";
                var side = "";
                var color = "";
                // this.deskList = response.body;
                this.T_Product_office_desk = response.body.T_Product_office_desk;
                this.T_Product_office_desk_detail = response.body.T_Product_office_desk_detail;
                //this.descriptions = response.body.descriptions;

                this.deskSerialName = this.T_Product_office_desk.deskSerialName;
                this.configurationNo = this.T_Product_office_desk_detail.configurationNo;
                //this.introduction = this.T_Product_office_desk_detail.introduction;

                //添加到产品配置列表 立柱
                if (this.T_Product_office_desk_detail.T_Part_office_Column != null) {

                    //立柱的参数表
                    var it = this.T_Product_office_desk_detail.T_Part_office_Column;
                    var paramList = new Array();
                    var statelist = new Array();
                    //if (it.Type != '') {
                    //    statelist.push("安装方向：" + it.Type);
                    //}
                    //if (it.Level != '') {
                    //    statelist.push("节数：" + it.Level);
                    //}
                    //if (it.Form != '') {
                    //    statelist.push("管形形状：" + it.Form);
                    //}

                    if (it.StrokeLength != '') {
                        statelist.push(this.ProductDetailLength + "：" + it.StrokeLength);
                    }
                    //if (it.MaxStroke != '') {
                    //    statelist.push("最大行程：" + it.MaxStroke);
                    //}
                    if (it.LoadCapacity != '') {
                        statelist.push(this.ProductDetailLoad + "：" + it.LoadCapacity);
                    }
                    //if (it.MaxLoad != '') {
                    //    statelist.push("最大负载：" + it.MaxLoad);
                    //}
                    if (it.Speed != '') {
                        statelist.push(this.ProductDetailSpeed + "：" + it.Speed);
                    }
                    this.descriptions = statelist;
                    for (i in this.T_Product_office_desk_detail.T_Part_office_Column.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_Column.T_Part_office_describes[i].textValue);
                    }

                    var q = { part: this.text_detail_11, model: this.T_Product_office_desk_detail.T_Part_office_Column.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_Column.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                    column = it.Mode;
                }
                //添加到产品配置列表
                if (this.T_Product_office_desk_detail.T_Part_office_Foot != null) {

                    var it = this.T_Product_office_desk_detail.T_Part_office_Foot;
                    var paramList = new Array();
                    //if (it.MaxLength != '') {
                    //    paramList.push("最大长度：" + it.MaxLength);
                    //}
                    //if (it.MinLength != '') {
                    //    paramList.push("最小长度：" + it.MinLength);
                    //}

                    for (i in this.T_Product_office_desk_detail.T_Part_office_Foot.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_Foot.T_Part_office_describes[i].textValue);
                    }

                    var q = { part: this.text_detail_12, model: this.T_Product_office_desk_detail.T_Part_office_Foot.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_Foot.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                    foot = it.Mode;
                }
                //添加到产品配置列表
                if (this.T_Product_office_desk_detail.T_Part_office_Frame != null) {

                    var it = this.T_Product_office_desk_detail.T_Part_office_Frame;
                    var paramList = new Array();

                    for (i in this.T_Product_office_desk_detail.T_Part_office_Frame.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_Frame.T_Part_office_describes[i].textValue);
                    }

                    var q = { part: this.text_detail_13, model: this.T_Product_office_desk_detail.T_Part_office_Frame.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_Frame.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                    frame = it.Mode;
                }
                //添加到产品配置列表
                if (this.T_Product_office_desk_detail.T_Part_office_SideBracket != null) {
                    var it = this.T_Product_office_desk_detail.T_Part_office_SideBracket;
                    var paramList = new Array();

                    for (i in this.T_Product_office_desk_detail.T_Part_office_SideBracket.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_SideBracket.T_Part_office_describes[i].textValue);
                    }

                    var q = { part: this.text_detail_14, model: this.T_Product_office_desk_detail.T_Part_office_SideBracket.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_SideBracket.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                    side = it.Mode;
                }
                if (this.T_Product_office_desk_detail.T_Part_office_ControlBox != null) {
                    var it = this.T_Product_office_desk_detail.T_Part_office_ControlBox;
                    var paramList = new Array();

                    for (i in this.T_Product_office_desk_detail.T_Part_office_ControlBox.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_ControlBox.T_Part_office_describes[i].textValue);
                    }

                    var q = { part: this.text_detail_15, model: this.T_Product_office_desk_detail.T_Part_office_ControlBox.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_ControlBox.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                    control = it.Mode;
                }
                if (this.T_Product_office_desk_detail.T_Part_office_HandSet != null) {
                    var it = this.T_Product_office_desk_detail.T_Part_office_HandSet;
                    var paramList = new Array();

                    for (i in this.T_Product_office_desk_detail.T_Part_office_HandSet.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_HandSet.T_Part_office_describes[i].textValue);
                    }

                    var q = { part: this.text_detail_16, model: this.T_Product_office_desk_detail.T_Part_office_HandSet.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_HandSet.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                    handset = it.Mode;
                }
                if (this.T_Product_office_desk_detail.T_Part_office_Powercable != null) {
                    var it = this.T_Product_office_desk_detail.T_Part_office_Powercable;
                    var paramList = new Array();

                    for (i in this.T_Product_office_desk_detail.T_Part_office_Powercable.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Part_office_Powercable.T_Part_office_describes[i].textValue);
                    }
                    //console.log(this.T_Product_office_desk_detail.T_Part_office_Powercable);
                    var q = { part: this.text_detail_17, model: this.T_Product_office_desk_detail.T_Part_office_Powercable.Mode, name: '', tag: this.T_Product_office_desk_detail.T_Part_office_Powercable.PictureName, paramList: paramList };
                    this.paramTableData.push(q);
                }
                if (this.T_Product_office_desk_detail.T_Office_Color != null) {
                    var it = this.T_Product_office_desk_detail.T_Office_Color;
                    var paramList = new Array();

                    for (i in this.T_Product_office_desk_detail.T_Office_Color.T_Part_office_describes) {
                        paramList.push(this.T_Product_office_desk_detail.T_Office_Color.T_Part_office_describes[i].textValue);
                    }
                    var q = { part: this.text_detail_18, model: this.T_Product_office_desk_detail.T_Office_Color.ColorName, name: '1', tag: this.T_Product_office_desk_detail.T_Office_Color.HEXValue, paramList: paramList };
                    this.paramTableData.push(q);
                    color = it.ColorNumber;
                }
                initQRCode('qrcodebox', 'http://config.jiecang.com:8866/JCSelection/ProductDetail?domain=' + '&Type=' + this.Type + '&recommend=' + this.recommend + '&productName=' + this.productName + '&productGuid=' + this.productGuid);
                //initQRCode('qrcodebox', 'http://config.jiecang.com:8866/JCSelection/Main');
                // console.log(this.T_Product_office_desk_detail);
                var ni = 0;
                for (ni in response.body.T_Office_Files) {
                    var item = response.body.T_Office_Files[ni];
                    switch (item.Nature) {

                        case "产品介绍": this.files_d1.push(item); break;

                        case "产品图2D": this.files_d2_2D.push(item); break;
                        case "产品图3D": this.files_d2_3D.push(item); break;

                        case "认证": this.files_d3.push(item); break;

                        case "文件资料": this.files_d4.push(item); break;
                        default:
                    }

                }
                //收藏的逻辑
                if (response.body.collect != null && response.body.collect.Id > 0) {
                    this.isCollect = true;
                }
                var url = checkProductDetailUrl(column, frame, foot, side, control, handset, color);
                this.oldcolor = color;
                this.filename = url;
                var apiaddress = "https://webapi.partcommunity.com/cgi-bin/cgi2pview.exe?cgiaction=preview&part={jiecang/lifting_table/jc36ts/jc36ts_asmtab.prj}";
                var apioption = "&firm=jiecang&viewerOptions=%7B%22webglViewerSettings%22%3A%7B%22ColorTL%22%3A%22%23EFF2F6%22%2C%22ColorTR%22%3A%22%23EFF2F6%22%2C%22ColorML%22%3A%22EFF2F6%22%2C%22ColorMR%22%3A%22EFF2F6%22%2C%22ColorBL%22%3A%22%23EFF2F6%22%2C%22ColorBR%22%3A%22%23EFF2F6%22%7D%7D&apikey=e20d66d8bb834f2497a101cff347a2d0";
                var totalurl = apiaddress + url + apioption;
                this.modelurl = totalurl;
                //console.log(url);
                var i = '<iframe scrolling="no"  id="shjahs"  alt=""  src = "' + totalurl + '"/>';
                $('#asas').append(i);
                //console.log(response.body);
                this.getAllColor();

            }, function (error) {
                //console.log(error);
            })
        },
        orderBtnClick: function (ordervalue) {
            this.OrderValue = ordervalue;
            if (this.Order == 1) {
                this.Order = 2;
            }
            else {
                this.Order = 1;
            }
        },
        setData: function (field, val) {
            this.$set(this.$data, field, val);//vue 设定值
        },
        download() {
            var element = $("#pdfDom");    // 这个dom元素是要导出pdf的div容器
            var w = element.width();    // 获得该容器的宽
            var h = element.height();    // 获得该容器的高
            var offsetTop = element.offset().top;    // 获得该容器到文档顶部的距离
            var offsetLeft = element.offset().left;    // 获得该容器到文档最左的距离
            var canvas = document.createElement("canvas");
            var abs = 0;
            var win_i = $(window).width();    // 获得当前可视窗口的宽度（不包含滚动条）
            var win_o = window.innerWidth;    // 获得当前窗口的宽度（包含滚动条）
            if (win_o > win_i) {
                abs = (win_o - win_i) / 2;    // 获得滚动条长度的一半
            }
            canvas.width = w * 2;    // 将画布宽&&高放大两倍
            canvas.height = h * 2;
            var context = canvas.getContext("2d");
            context.scale(2, 2);
            context.translate(-offsetLeft - abs, -offsetTop);
            // 这里默认横向没有滚动条的情况，因为offset.left(),有无滚动条的时候存在差值，因此
            // translate的时候，要把这个差值去掉
            html2canvas(element, { background: '#FFF' }).then(function (canvas) {
                var contentWidth = canvas.width;
                var contentHeight = canvas.height;
                //一页pdf显示html页面生成的canvas高度;
                var pageHeight = contentWidth / 592.28 * 841.89;
                //未生成pdf的html页面高度
                var leftHeight = contentHeight;
                //页面偏移
                var position = 0;
                //a4纸的尺寸[595.28,841.89]，html页面生成的canvas在pdf中图片的宽高
                var imgWidth = 595.28;
                var imgHeight = 592.28 / contentWidth * contentHeight;
                var pageData = canvas.toDataURL('image/jpeg', 1.0);
                var pdf = new jsPDF('', 'pt', 'a4');
                //有两个高度需要区分，一个是html页面的实际高度，和生成pdf的页面高度(841.89)
                //当内容未超过pdf一页显示的范围，无需分页
                if (leftHeight < pageHeight) {
                    pdf.addImage(pageData, 'JPEG', 0, 0, imgWidth, imgHeight);
                } else {    // 分页
                    while (leftHeight > 0) {
                        pdf.addImage(pageData, 'JPEG', 0, position, imgWidth, imgHeight)
                        leftHeight -= pageHeight;
                        position -= 841.89;
                        //避免添加空白页
                        if (leftHeight > 0) {
                            pdf.addPage();
                        }
                    }
                }
                var d = new Date();
                var y = d.getFullYear();
                var m = d.getMonth()+1;
                var day = d.getDate();               
                pdf.save(y.toString() + m.toString() + day.toString() + name);
            })
        },
        colorClick: function (id, mode, number) {
            if (this.select_Color == id) {
                return;
            }
            this.select_Color = id;
            this.select_ColorMode = mode;
            this.colour_color = number;
            this.SetFrame(this.modelurl, this.colour_color);
        },
        getAllColor: function (event) {
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/GetSimpleOfficeColor",
                params: {
                }
            }).then(function (response) {  //接口返回数据


                this.list_Color = response.body;


                this.list_Color_count = this.list_Color.length;
                //console.log(this.list_Color);
            }, function (error) {
                //console.log(error);
            })
        },
        SetFrame: function (url, color) {
            if (this.select_Color != "") {
                var src = url.replace(",{COLOUR=" + this.oldcolor + "}", ",{COLOUR=" + color + "}");

                //    alert(src);

                $("#shjahs").attr({
                    "src": src
                });

            }
            else {
                $("#shjahs").attr({
                    "src": ""
                });
            }
            //console.log(src);
            //  console.log(base);





        },
        order: function (event) {
            this.$notify.closeAll();
            if (this.format != '') {
                if (this.username != '') {
                    console.log("1");
                    this.loading = true;
                    this.isAble = true;
                    $.post("https://webapi.partcommunity.com/cgi-bin/cgi2pview.exe", {
                        cgiaction: "download",
                        downloadflags: "ZIP",
                        part: "{jiecang/lifting_table/jc36ts/jc36ts_asmtab.prj}" + this.filename,
                        firm: "jiecang",
                        format: this.format,
                        ok_url: "<%download_xml%>", // format of the url to generate
                        ok_url_type: "text", // we want a direct text response (no 302)
                        apikey: "e20d66d8bb834f2497a101cff347a2d0",
                        zipfilename: "Jiecang<%wkbno%>",
                    }).done(function (data) {
                        download_xml = data; // get the file name for polling
                        //console.log(this.format);
                        checkFile(); // start polling
                    });
                }
                else {
                    this.$message({
                        type: 'error',
                        message: this.DownloadNoRight
                    });
                }
            }
            else {
                this.$notify.error(this.DownloadChooseOneType);
            }
        },
        setloading() {
            this.loading = false;
            this.isAble = false;
        }
    }
})
//语言加载
OfficeStandards.initPage();
OfficeStandards.getThisDesk();
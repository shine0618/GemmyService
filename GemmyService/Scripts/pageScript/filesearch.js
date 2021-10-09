var filesearch = new Vue({
    el: "#filesearch",
    data: {
        NAVMainPage: '',
        CustomPage: '',
        partType: '',
        Nature: '',
        Mode: '',


        FileSearchTitle: "",
        FileSearchSelectType: "",
        FileSearchSelectColumn: "",
        FileSearchSelectHandset: "",
        FileSearchSelectControlbox: "",
        FileSearchSelectFoot: "",
        FileSearchSelectSidebracket: "",
        FileSearchSelectFrame: "",
        FileSearchSelectPowercable: "",
        FileSearchSelectAccessory: "",
        FileSearchSelectDesk: "",
        FileSearchSelectFileType: "",
        FileSearchSelectFileTypeDesc: "",
        FileSearchSelectFileType2D: "",
        FileSearchSelectFileType3D: "",
        FileSearchSelectFileTypeCert: "",
        FileSearchSelectFileTypeDoc: "",
        FileSearchMode: "",
        FileSearchModeBtn: ""

    },
    methods: {
        initPage: function (event) {
            var code = GetLanguCode();
            this.langCode = code;
            $.ajaxSettings.async = false;
            var level = GetLoginLevel();
            if (level < 1) {
                window.location.href = "/JCSelection/main";
            }
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
                    this.setData(key, value);
                }
            }
            var url = "https://jiecang-embedded.partcommunity.com/3d-cad-models/sso/jc36tViewBag-%E5%8D%87%E9%99%8D%E6%A1%8C-%E6%8D%B7%E6%98%8C?info=jiecang%2Flifting_table%2Fjc36ts_asmtab.prj&cwid=6919&showPortlets=preview&hidePortlets=navigation&languageIso=" + this.langCode;
            var i = '<iframe scrolling="yes"  id="shjahs"  alt=""  src = ""/>';

            $('#asas').append(i);
        },
        setData: function (field, val) {
            this.$set(this.$data, field, val);//vue 设定值
        },
        searchclick: function (event) {

            var nature = '';
            for (var i = 0; i < this.Nature.length; i++) {
                if (i < this.Nature.length - 1) {
                    nature += this.Nature[i] + '|';
                }
                else {
                    nature += this.Nature[i];
                }
            }
            //console.log(nature);
            var src = "/JCSelection/FileTree?parttype=" + this.partType + "&nature=" + nature + "&mode=" + this.Mode;
            //console.log(src);
            $("#shjahs").attr({
                "src": src
            });
        }
    },
})
filesearch.initPage();
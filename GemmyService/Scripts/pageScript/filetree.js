var parttype = GetFileparttype();
var nature = GetFilenature();
var mode = GetFilemode();
$(function () {
    $('.bottom-footer').hide();
    $('.main-menu').hide();
})
var filedetail = new Vue({
    el: '#filedetail',
    data() {
        return {
            data: [],
            parttype: parttype,
            nature: nature,
            mode: mode,
            filelist: [],


            FileTreeDownloadBtn: "",
            FileTreeDesc: "",
            FileTree2D: "",
            FileTree3D: "",
            FileTreeCert: "",
            FileTreeDoc: ""
        }
    },
    methods: {
        getfile() {
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
            var m = [{
                id: 1,
                label: this.FileTreeDesc,
                children: [],
            },
            {
                id: 2,
                label: this.FileTree2D,
                children: [],
            },
            {
                id: 3,
                label: this.FileTree3D,
                children: [],
            },
            {
                id: 4,
                label: this.FileTreeCert,
                children: [],
            },
            {
                id: 5,
                label: this.FileTreeDoc,
                children: [],
            }];
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/getFileByDetail",
                params: {
                    parttype: this.parttype,
                    nature: this.nature,
                    mode: this.mode,
                }
            }).then(function (response) {  //接口返回数据
                this.filelist = response.body;
                for (var i = 0; i < response.body.length; i++) {
                    switch (response.body[i].Nature) {
                        case "文件资料": const a = { id: i + 6, label: response.body[i].FileName + response.body[i].Type };
                            if (!m[4].children) {
                                this.$set(m[4], 'children', []);
                            }
                            m[4].children.push(a);
                            break;
                        case "认证": const b = { id: i + 6, label: response.body[i].FileName + response.body[i].Type };
                            if (!m[3].children) {
                                this.$set(m[3], 'children', []);
                            }
                            m[3].children.push(b);
                            break;
                        case "产品图3D": const c = { id: i + 6, label: response.body[i].FileName + response.body[i].Type };
                            if (!m[2].children) {
                                this.$set(m[2], 'children', []);
                            }
                            m[2].children.push(c);
                            break;
                        case "产品图2D": const d = { id: i + 6, label: response.body[i].FileName + response.body[i].Type };
                            if (!m[1].children) {
                                this.$set(m[1], 'children', []);
                            }
                            m[1].children.push(d);
                            break;
                        case "产品介绍": const e = { id: i + 6, label: response.body[i].FileName + response.body[i].Type };
                            if (!m[0].children) {
                                this.$set(m[0], 'children', []);
                            }
                            m[0].children.push(e);
                            break;
                    }
                }
                //console.log(this.filelist);
            }, function (error) {
                //console.log(error);
            })
            this.data = m;
        },
        append(data) {
            const newChild = { id: id++, label: 'testtest', children: [] };
            if (!data.children) {
                this.$set(data, 'children', []);
            }
            data.children.push(newChild);
        },

        remove(node, data) {
            const parent = node.parent;
            const children = parent.data.children || parent.data;
            const index = children.findIndex(d => d.id === data.id);
            children.splice(index, 1);
        },
        handleCheckChange() {
            let res = this.$refs.tree.getCheckedNodes()
            let arr = []
            res.forEach((item) => {
                if (item.id > 5) {
                    arr.push(item.id)
                }

            })
            //console.log(arr);
            for (var i = 0; i < arr.length; i++) {
                var fname = this.filelist[arr[i] - 6].FileName;
                if (this.filelist[arr[i] - 6].Type == ".dwg" || this.filelist[arr[i] - 6].Type == ".stp") {
                    fname = this.filelist[arr[i] - 6].FileName + this.filelist[arr[i] - 6].Type;
                }
                const link = document.createElement('a');
                link.style.display = 'none';
                link.href = this.filelist[arr[i] - 6].Path;
                link.setAttribute('download', fname);
                document.body.appendChild(link);
                link.click();
            }
        },
        setData: function (field, val) {
            this.$set(this.$data, field, val);//vue 设定值
        },
    },
})
filedetail.getfile();
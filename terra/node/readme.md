1.将本次升级需要用到的头文件比如4.3.1提交到terra_shared_configs仓库里。并且被合并到main分支上
2.首先修改terra_config.yaml文件。将里边的版本号修改为你想要的版本号。
3.删除yarn.lock文件中的所有内容，删除node_modules文件夹, 删除.terra文件夹
4.控制台运行 yarn 以安装yarn
5.控制台运行 npm run terra_json 以生成 C++的数据的json
6.打开src/test.ts文件，搜索terra_shared_configs关键字，将头文件的路径修改为比如4.3.1
7.运行 sh build.sh 以生成代码

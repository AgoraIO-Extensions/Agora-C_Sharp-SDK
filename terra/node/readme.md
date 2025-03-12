1.将本次升级需要用到的头文件比如4.3.1提交到terra_shared_configs仓库里。并且被合并到main分支上
2.首先修改terra_config.yaml文件。将里边的版本号修改为你想要的版本号。
3.打开src/test.ts文件，搜索terra_shared_configs关键字，将头文件的路径修改为比如4.3.1
4.sh prepare.sh
5.sh build.sh

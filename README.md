# grpcC#版
包括C#版的客户端和服务端
## 生成代码方法
首先,添加项目依赖的包,使用nuget包管理器添加如下包:
* Google.Protobuf
* Grpc
* Grpc.Tools(用于生成代码,如果代码不在这里生成,可以忽略)

使用代码生成工具生成,位于`<解决方案>\packages\Grpc.Tools.1.9.0\tools`,选择对应的系统版本,运行以下命令:
```
 .\protoc.exe --csharp_out=. --grpc_out=. --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe .\hello.proto
```
* --csharp_out=.  在当前目录生成c#版的prtoobuf类.
* --grpc_out=.  在当前目录生成grpc相关的类
* --plugin  指定使用插件
* protoc-gen-grpc=grpc_csharp_plugin.exe   指定生成c#代码的插件位置
* .\hello.proto   要生成的proto文件

生成后,会生成`Hello.cs`和`HelloGrpc.cs`两个文件,复制到项目中
# grpcC#��
����C#��Ŀͻ��˺ͷ����
## ���ɴ��뷽��
����,�����Ŀ�����İ�,ʹ��nuget��������������°�:
* Google.Protobuf
* Grpc
* Grpc.Tools(�������ɴ���,������벻����������,���Ժ���)

ʹ�ô������ɹ�������,λ��`<�������>\packages\Grpc.Tools.1.9.0\tools`,ѡ���Ӧ��ϵͳ�汾,������������:
```
 .\protoc.exe --csharp_out=. --grpc_out=. --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe .\hello.proto
```
* --csharp_out=.  �ڵ�ǰĿ¼����c#���prtoobuf��.
* --grpc_out=.  �ڵ�ǰĿ¼����grpc��ص���
* --plugin  ָ��ʹ�ò��
* protoc-gen-grpc=grpc_csharp_plugin.exe   ָ������c#����Ĳ��λ��
* .\hello.proto   Ҫ���ɵ�proto�ļ�

���ɺ�,������`Hello.cs`��`HelloGrpc.cs`�����ļ�,���Ƶ���Ŀ��
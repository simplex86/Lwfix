# Fixed.Net

基于.Net的有符号定点数库，（计划）包含以下几个模块

- [ ] Numeric
	- [x] Fixed32
	- [ ] Fixed64
- [x] Math
- [x] Vector
	- [x] Vector2
	- [x] Vector3
- [x] Matrix
	- [x] Matrix3x3
	- [x] Matrix4x4
- [x] Quaternion
- [ ] Random
- [ ] Physics
	- [ ] 2D
	- [ ] 3D

> [!NOTE]
> 打勾的是已经完成的内容

目前计划只会提供两种基础的定点数类型，Q32.32 格式的 Fixed32 和 Q64.64 格式的 Fixed64。它们都约束与 IFixed 接口，FMath、FVector2、FVector3、FMatrix3x3、FMatrix4x4、FQuaternion 都是泛型的，它们都可以直接支持约束与 IFixed 接口的自定义类型。由此，您完全可以定义您需要的定点数类型，例如 Fixed128，只要它也约束与 IFixed 接口。

写这个库的初衷是基于 Unity3D 做游戏时需要使用到定点数，所以大部分接口都和 UnityEngine 中一致（有个别不同），您可以参照 Unity3D 的文档来使用该库提供的接口（或许后续会逐步完善相关的注释和文档）

> [!WARNING]
> 就代码风格而言，和 Unity3D 还是有一点区别的：**属性的首字母大写**
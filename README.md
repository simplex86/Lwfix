# Lwfix

Lwfix 是基于 .Net 的有符号定点数库，包含以下几个模块

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
- [x] Random

> 打勾的是已经完成的内容

## 说明

- Q32.32 格式的 Fixed32（已完成） 和 Q64.64 格式的 Fixed64（未完成）都约束于 IFixed 接口的。FMath、FVector2、FVector3、FMatrix3x3、FMatrix4x4、FQuaternion、FRandom 等是泛型的，它们都支持约束于 IFixed 接口的自定义类型。由此，您完全可以定义您需要的定点数类型，例如 Fixed128，只要它也约束于 IFixed 接口。

- 写这个库的初衷是基于 Unity3D 做游戏时需要确保多平台下小数计算的一致性，所以大部分接口都和 UnityEngine 中一致（有个别不同），您可以参照 Unity3D 的文档来使用该库提供的接口（后续会逐步完善注释和文档）。

> [!WARNING]
> 虽然接口的命名尽可能和 UnityEngine 保持一致，但就代码风格而言还是有区别的：**属性的首字母大写**。

## 测试

为了尽可能保持工程简洁，所有的测试都放在了独立的 [Lwfix-Test](https://github.com/simplex86/Lwfix-Test) 项目中。

> [!TIP]
> 测试工程主要检验各个接口的正确性，并不涉及性能。

## TODO

- 物理引擎

	原计划在现有的基于 C# 实现的物理引擎基础上修改出对应的定点数版本，但因为没有熟悉的引擎可直接使用，这项计划有较大的学习成本。

- [ ] Physics
	- [ ] 2D
	- [ ] 3D
		
- UnityEngine

	写这套代码的初衷是为了给基于 UnityEngine 开发的游戏提供具有计算一致性的定点数，有完善且方便在 UnityEngine 下使用的各类组件似乎是必要的。但目前而言，在完成物理引擎移植后再进行这步计划意义更大些。

- [ ] Unity
	- [ ] Script
	- [ ] Editor
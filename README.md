# ヘビVR
Unityで実装した赤外線を可視化するファイル並びにアプリに利用した関連ファイル

[PV（リンク）](https://www.youtube.com/watch?v=cCAgF45Rq8Q)

[デモプレイ（リンク）](https://www.youtube.com/watch?v=fDU2Zfb23Mk)

## 赤外線の可視化
メインカメラにTemperatureMasterをアサインし、各オブジェクトにTemperatureAssignをアサインする。
その後、高温に見せたいオブジェクトのTemperatureAssign.temperature_degreeの数値を高くする。（低温の場合は低くする）
赤外線可視化状態にするにはTemperatureMasterのswitchflagをTrueにすることで、次のフレームで赤外線可視化処理を行う。
元の視界に戻す際は、再度switchflagをTrueにする。（もともとのオブジェクトの色はTemperatureAssignクラスに保持されており、それを呼び出す）

## TemperatureMaster.cs
赤外線可視化の有無を操作するクラス。
メインカメラにアサインし、switchflagを立ち上げる(true)ことで視界を(通常/赤外線)にスイッチする。
switchflagは次のフレームで自動的に下げられる(false)。

## TemperatureAssign.cs
赤外線可視化した時の温度を指定するクラス。
各オブジェクトにアサインし、temperature_degreeを高く設定すると高温、低く設定すると低温に見える。
元の色はこのクラスで保持され、赤外線可視化状態から通常の視界に戻す際に利用される。

## TheramlVision.shader, ThermalVisionSurfaceReplacement.shader
TemperatureMasterクラスで指定するシェーダーファイル

## RatControll.cs
フィールド内に餌を自動生成する。
rat変数にはプレハブ化したTouchedByHandsをアサインしてあるオブジェクトを指定する。

## TouchedByHands.cs
食べられるオブジェクトにアサインし、特定のColliderに接触すると消滅する機能。

## Biting.cs
飛びついて噛みつくモーション。

## MenuControll.cs
メニューのコントロール。

## Timer.cs
タイマー機能。

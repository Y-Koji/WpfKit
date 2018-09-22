
# WpfKit
## WPF実装を簡易的に行えるようにするツールキット

# 機能一覧
- INotifyPropertyChanged 自動実装
- EventTrigger

## INotifyPropertyChanged 自動実装
ViewModelクラスは以下のようなvirtual修飾子が付いた自動実装プロパティを宣言することで
自動的に値設定時にPropertyChangedを発火させることができます．

![](https://i.imgur.com/R4gkDLf.png)

DataContextへ設定する際には，以下のように専用添付プロパティを利用します．

![](https://i.imgur.com/nZuz4sC.png)

- WpfProperty.DataContext 添付プロパティにより引数に受け取ったViewModelオブジェクトを派生し新規型を生成，動的にvirtualプロパティをオーバーロードそれをWindowのデータコンテキストへ設定します．
- 添付プロパティにてデータコンテキストを設定するとバインディングの入力保管が聞かないため，d:DataContext を用いてデザイン時に利用するViewModelを指定しておきます．

## EventTrigger
任意のコントロールイベントを用いてコマンドの発火を行うことができます．

![](https://i.imgur.com/sdnNGix.png)
![](https://i.imgur.com/kvjZwtu.png)

# 追加作成予定
- 標準的なデザイン(Flat Dessign, Dark, Light)
- 画面遷移用の機構
- メッセージボックス等サブ画面表示用機構

asp.net Core Web APP (MODEL-VİEW-CONTROLLER) Olarak projemizi oluşturduk ve guvenlik amacıyla fazla sorun çikmamasi için https seçilmedi ve kodda yapılan 
değişiklikler viewlara anında yansıyabilsin diye anable razor runtime compilationu tercih ettik.

2- Models => entities klasörü ve altına abstract ve concrete olarak calışacagımız modellerimizi oluşturalım.
3- konfigurasyonlarımızı yazabilmek için EntityTypeConfiguration klasörünü ve içerisine abstract ve concrete başlıkları altında
konfigurasyonlarımızı yazdık.
	 konfigurasyonlarımızı yaparken EntityTypeConfiguration Dan Değil onun atasından yani interface halinde yararlanıyoruz.(IEntityTypeConfiguration)
 bu yüzden şekillendirmelerimizi da her sınıfın konstrctorına değil i implemente edip configure metotunun içerisine ekledik.
 konfigurasyonları tamamlayabilmek için bizden  mic.EFCORE.SQL paketini indir ki bunun içerisinde EFCORE paketide yer almaktadır

 4- konfigurasyon tamamlandıktan sonra Infrastructure adlı klasör acilir ve içine context sınıfımız için bi klasör açalım.

 5- connectionStringimizi bu kez context sınıfından değil appsettting.jsonda (program sabitleri için) yazacagız

 6- startUp İçerisinde iSE APPSETTİNG.jSONDAKİ ConnectionStringimizi söyleyeceğiz.
 7-  Context sınıfında oluşacak dbsetler belirtilir.
 8- context sınıfında OnmodelCreating de yaptıgımız Konfigurasyonları Söyleyelim.
 9- Mic.EFCORE.Tools paketi ve proxy paketi indirilir ki console manegerdan göç başlayabilsin

 10 - console dan bu kez add-migration isimVer diyerek ve ardından Update-database diyerek göç tamamlanır..

 11 - Infrastructure adını verdiğimiz bize yararlı dosyaları barındırdıgımız. klasöre repolarımız ekledi.

 12- repolarımızı oluştururken core bizden DI istediği için soyut katmandan gelmeye dikkat ediyoruz ve bu yüzden metotların önce interface hallerini
  devamında concrte hallerini oluşturabiliyoruz.

  13 -  sonrasında controllerimiz oluşturup CRUD operasyonlarına baslayabilirz.

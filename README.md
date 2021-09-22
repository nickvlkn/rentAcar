# rentAcar

VOLKAN YILDIZ ARAÇ KİRALAMA OTOMASYONU 2184257051
Programın amacı araç kiralama dır programda müşteri işlemleri (ekle sil güncelle görüntüle ara)  araç işlemleri (ekle sil güncelle görüntüle ara)  ve ekstra rapor işlemleri vardır . 9 adet form sayfasından oluşmaktadır bunları sırasıyla açıklayalım

1.	İndex :  Programı açtığımızda bizi karşılayacak olan form anasayfamız dır sol üstten başlarsak.
![home](https://user-images.githubusercontent.com/36370002/134341407-d41e6672-ec24-4c77-aea9-81669c1c42ff.png)


Menü: işlemler ve yardımdan oluşur 
1.	İşlemler
![menu](https://user-images.githubusercontent.com/36370002/134341506-b8da2387-a332-4be2-bd93-6544b2037331.png)

a- Araç Reismlerini aç dediğimiz de projemize eklediğimiz araçların klasörünü açar 
![image](https://user-images.githubusercontent.com/36370002/134341617-0df56f3e-ef96-4d92-b846-4371d677e558.png)
 
b-Veri tabanını aç dediğimizde  projemize eklediğimiz veri tabanını açar
![image](https://user-images.githubusercontent.com/36370002/134341691-de915349-a3a5-4ff0-856d-9be23190ee51.png)

c- kapat sekmesi ise programızı kapatır 


Nasıl kullanılırda programı öğreten word belgesi bulunacaktır.

![image](https://user-images.githubusercontent.com/36370002/134342037-dd37ec7d-ff49-45ec-8f3d-0fc3bf14ff7f.png)

İletişim
![image](https://user-images.githubusercontent.com/36370002/134342132-756a3f8c-0ebb-4927-9ce7-8adbc1d3feff.png)

Sözleşme örneği
![image](https://user-images.githubusercontent.com/36370002/134342216-d0e17aa1-bad8-4f74-8a29-c47d4beddb9c.png)

Boş bir sözleme örneği pdf i açar.
![image](https://user-images.githubusercontent.com/36370002/134342241-77700bd1-9e43-494c-9595-579022133f53.png)

2.Müşteri Ekle Sayfası
 ![image](https://user-images.githubusercontent.com/36370002/134342337-bc1186fa-d540-4460-abdc-b2edd4037bdc.png)

Sayfada müşteri ekel sil güncelle ara işlemleri bulunur .
KAYDET
Sol taraftan Müşteri ekle bölmünden sırasıyla bilgilerimizi girip kaydet değidiğimizde müşterimiz kaydedilmiş olacaktır.
ARA(TC-ARA)
Aramak istediğimiz müşterinin tc no sunu Müşteri ara-sil(tcno) bölümün deki textbox a yazıp  Tc Ara butonuna bastığımız da müşterimiz bilgileri Müşteri ekle  kısmına gelecektir.
Veya datagridviewden faremizin sol tıkı ile müşterimizi seçip tc ara dediğimizde aynı işlem olacaktır.
GÜNCELLE
Müşteri ekle kısmındaki bilgilerimizi getirdiğimize göre istediğimiz alandaki değişikliği yapıp Gücelle butonuna basarsak müşterimizi güncellenecektir.
TEMİZLE
 Temizle butonuna bastığımız sayfamızdaki dolu olan tüm text ler silinecektir.
SİL
Silmek isteidiğimiz müşterinin tc no sunu Müşteri ara-sil(tcno) textbox ına yazıp sil dediğimizde Müşterimiz silinecektir.(Fare ile seçip aynı işlemi yapabiliriz yazmadan)
Veya müşterimizi seçip Sağ tık yapıp sil diyip sile biliriz.
 
Sağ açılır menü
![image](https://user-images.githubusercontent.com/36370002/134342384-dde14307-966f-4e1c-b932-8933c5426002.png)

YENİLE: veri tabanından çektiğimiz bilgileri yeniler.
SİL: seçili olan müşteriyi siler.

3.Araç  Ekle Sayfası
![image](https://user-images.githubusercontent.com/36370002/134342435-2f6cd4cb-cc69-4212-ac88-1e1f11985c6e.png)

 
Sayfada  müşteri sayfasındaki işlemlerin aynısı yapıp araçlarımızı görüntüleye biliriz.
GÜNCELLE(Düzenle)
Araç bilgileri kısmındaki bilgilerimiz istediğimiz alandaki değişikliği yapıp Düzenle butonuna basarsak müşterimizi güncellenecektir.
RESİM EKLE
Araç resmizi seçmemiz için bir pencere açar ve sadece .jpg .jepeg formatındaki fotoğrafları görüntüler  ve seçmemize olanak tanır.
RAPOR
![image](https://user-images.githubusercontent.com/36370002/134342483-867c175e-3e18-4848-b258-9d54fa3fdf38.png)

Sayfada var olan araçlarmızı görüntüleye biliriz .
Zoom için tekerleği kullanın.
Model : textbox ına model yılını yazıp RAPOR OLUŞTUR dediğimizde o yıla ait araçlar gelcektir .
Yazdır: yazdırma işlemi.







4.Araç  Kirala Sayfası
Müşteri ve araç seçip araç kiralaya biliriz.
![image](https://user-images.githubusercontent.com/36370002/134342588-f971ffe2-367b-40e4-8c45-9a09c05c2689.png)

 
KİRALANABİLİR ARAÇLAR 
Buradan datagridviewden fare sol tık ile seçim yaptığımızda araç resmi Araç Resmine gider ve bilgileri
İşlem Sekmesine gider.
MÜŞTERİLER 
KİRALANABİLİR ARAÇLAR İle aynı işem buradada geçerlidir ama müşterinin resmi yoktur.
KİRALA
![image](https://user-images.githubusercontent.com/36370002/134342653-896c6096-64df-44af-8b07-ef5c60fe7a74.png)

Kiraladığımızda araç kiralanmış araçlara düşer.

YAZDIR
![image](https://user-images.githubusercontent.com/36370002/134342756-b0ff7f03-467d-4354-8644-feddc5f34b7f.png)

Yazdır deidiğimide karşımıza söleşme öreneği çıkar ve burada müşteri ve araç bilgileri seçimlerimize göre dolu gellir çıktısını alıp gerekli işlemler yapılır.




5.Araç  Teslim Sayfası
Teslim alınacak aracı seçip TESLİM AL dediğimizde aracımız teslim alınacaktır.

![image](https://user-images.githubusercontent.com/36370002/134342813-198ac433-8c2a-4bf0-9230-126501e75c78.png)
![image](https://user-images.githubusercontent.com/36370002/134342837-deafcb9b-503e-4373-9655-a4ac18499683.png)

6 .Tarih Rapola Sayfası
İstediğimiz 2 tarih arasını seçip GÖSTER dediğimizde o tarihler arasında  yapılan araç kiralama işlemleri gelecektir.
![image](https://user-images.githubusercontent.com/36370002/134342903-c38401ad-20e9-49e2-ba73-4c5c2d75a040.png)

Notfy icon
![image](https://user-images.githubusercontent.com/36370002/134342974-4a22acdc-a14a-410e-8739-8ed9468de812.png)

 
VERİ TABANI: volkan rent a car\rentacar\rentacar\bin\Debug\rentacarverit.accdb

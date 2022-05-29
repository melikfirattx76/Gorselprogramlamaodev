# Görsel ProgramlamaOdevi
Projeyi sahibi : Melik Fırat Vural , Mert Poyraz
 
Proje Adı : Araç alım satım sistemi 
 
Proje Amacı : Kullanıcıların araba alım satım ve arabalarını listeleyebilmeleri için bir sistem

Projenin çalışma olayı kullanıcılar sisteme kayıt olup ondan sonra giriş yapmalıdırlar.Karşısına gelen ekranda kullanıcılar eklenmiş bütün arabaları listeleyebilir

kendi arabalarını ekleyebilir ve kendi ekledikleri arabaları güncelleyebilir,silebilir.Programda sadece kullanıcılar kendi arabaları üzerinde güncelleme ve 
silme işlemini yapabilir.Bir başka kullanıcının eklediği arabanın üzerinde güncelleme ve silme işlemi yapamaz.
Arama kısmına gelindiğinde ise bir araba markası veya modeli yazarak ve vites durumunun seçerek ekli olan arabalar içinde arama yapabilirler.


# Araştırma konusu : Selenium
Araştırma konuma internette gezerken denk geldim ve inceledikten sonra beğendiğim ilgimi çeken bir konuydu ve kendi projeme uyarlamak istedim.

Selenium Nedir?

Farklı tarayıcılarda yada ortamda web uygulamalarını test etmek için kullanılan test çerçevesidir(framework). Başka bir deyişle, web uygulamalarının kalite güvencesi için kullanılan yazılım test otomasyon araçlar paketidir. Ayrıca açık kaynaklı yazılım olduğu için ücretsizdir. Test Komut Dosyaları için C#, Pyhton, Java gibi birden fazla programlama dili kullanılır

Projemde arama kısmında ekli olan arabalar içinde istediğimiz arabayı bulamadıysak en alttaki kutucuğa istediğimiz araba ismini girerek İnternette arama yap 
butonuna basıyoruz ve gerisini selenium bizim için hallediyor.

!!! Selenium kodlarının çalışması için son sürüm (102.0.5005 sürümüne) google chrome ihtiyaç vardır.Daha eski bir google chrome sürümü
kullanıyorsanız çözüm gezginine sağ tıklayıp manage nuget packages for solution kısmından Selenium.WebDriver.ChromeDriver isimli
paketi seçip kullandığınız google chrome sürümünü version kısmından install edip kurulu olan 102.0.5005.6100 sürümünü uninstall etmelisiniz.

![Selenium](https://user-images.githubusercontent.com/106485733/170883953-8ce08934-cc2b-441b-9869-cdfcc0588f65.gif)

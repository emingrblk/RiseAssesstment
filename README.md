Notlar:
ContactService ve ReportService içerisindeki, Appsetting.Json dosyası içinde,Db bağlantısı için ConnectionString(PostgreSql) ve RabbitMQ için MessageBrokerOptions değerlerinin değiştirilmesi gerekmektedir. Otomatik Migration Uygulanıyor. SeedData Eklendi. Zaman Azlığından UnitTest , FluentValidation kullanılmamıştır. 

Teknolojiler .NetCore WebApi RabbitMQ Swagger PostgreSql

Test Api User;
user: admin@admin.com  
password: Asd123


Web Api İstekleri ve anlamları;

ContactService:

/api/Auth/login :Token üretir. Projede Jwt Bearer Token kullanıldığından, Diğer istekler için token alınması gerekmektedir.

/api/Contacts : Tüm Kişileri Çeker

/api/Contacts/{id} : Id'e ait Kişiyi Çeker.

/api/Contacts/add : Kişi Ekler

/api/Contacts/update : Kişiyi günceller

/api/Contacts/delete/{id} : Id'e ait Kişiyi Siler.

/api/ContactDetails/add/{contactId} : ContactId'e göre İletişim Bilgisi Ekler.

/api/ContactDetails/update/{contactId} : ContactId'e göre İletişim Bilgisini Günceller.

/api/ContactDetails/delete/{contactDetailId} : ContactDetailId'ye göre İletişim Bilgisini Siler.

/api/ReportRequests/RequestReport/{location} : Lokasyon için Rapor İsteği Yapar (RabbitMq Producer)

ReportService:

/apies/Auth/login :Token üretir. Projede Jwt Bearer Token kullanıldığından, Diğer istekler için token alınması gerekmektedir.

/apies/Reports : Tüm Raporları Getirir.

/apies/Reports/{id} : Verilen Id'e ait raporları getirir.


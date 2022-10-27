# BookingSystem_Zhadovich_Michail
учебный проект  -   приложение для бронирования билетов на мероприятия

**для запуска в Visual studio необходимо:**
 * установить Node.js
 * в Visual studio сменить launch profile  с   IIS Express на  BookingSystem.WEB

 #### особенности
 * отключена внешняя аутентификация
 * UseInMemoryDatabase вместо UseSqlServer
 * отключены транзакции(не поддерживаются UseInMemoryDatabase)

база данных создается в памяти с тестовым содержимым.

### тестовые пользователи
**данные берутся из appsettings.json - "DefaultUsers".**
* Sklif83@tut.by    администратор
* test1@tut.by      заблокированный пользователь
* test2@tut.by      активный пользователь

* sb-lmb1u21534847-1@personal.example.com     тестовый пользователь PayPal 
* пароль везде   asdf1234

адрес приложения
https://localhost:5001

опубликована 
https://bookingsystem-zhadovichmichail.herokuapp.com/

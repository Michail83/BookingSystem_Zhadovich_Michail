# BookingSystem_Zhadovich_Michail
учебный проект  -   приложение для бронирования билетов на мероприятия

__ для запуска в Visual studio необходимо:__
 * установить npm
 * в Visual studio сменить launch profile  с   IIS на  BookingSystem.WEB


от ветки  master отличается  
     -  UseInMemoryDatabase вместо UseSqlServer
     - отключены транзакции(не поддерживаются UseInMemoryDatabase)

база данных создается в памяти с тестовым содержимым.

**данные на дефолтного администратора берутся из appsettings.json - "DefaultAdmin".**
* Email      Sklif83@tut.by
* Password   asdf1234


адрес приложения
https://localhost:5001 

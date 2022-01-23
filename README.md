# Parfum Ecommerce Windows Forms,For ADO.Net Connected And Disconneced 
> Bu repo mənim Windows Forms,MsSQL və ADO.Net Connected və Disconneced Modellərindən istifadə bacarğımı göstərmək üçün yaradılmış lahiyyədir.Parfum satışı üçün hazırlanmış bir appdir.Bir Ecommerce saytina əsaslanaraq yardımışdır.Ümumən bu appdə Connectionları az tutulmağa çalışıb.
> 3 versiyası olacaqadır.
1. Admin panel  
2. Employee
3. User

## Admin panel 
> Userlərin və Employee şatışına nəzarət etmək,Userlərin və Employeenin accesslərini dəyərləndirmək üçün və lazım gəldikdə isə dəyişikliklər etmək(Delete and Update) üçün fikirləşilib.Təbiki Parfum yaratam və satış edə bilir. 

## Employee
> Userlərin satışına baxmaq,Yardılmış bütün parfümlərə baxmaq, Yeni parfumlərin yardılması və parfümlərin qəblulunu edə bilir və Satış edir.

## User
> Satışda olan bütün parfümləri görür və alış edə bilir.Satışda olan bütün pafümləro acatara bilir.


## DataBase
> Database olaraq **MsSQL**dən istifadə eilib. Atfter delete və update triggerlərindən,Function,Procedure və Viewlardan istifadə edilib. Yuxarıda qeyd etiklərimdən bir neçəsini izahanı verirəm.After Updated Triggeri satış olduqda bu satışın miqdarı qədər `SalePrice Table`dan silinir.Əgər satış silinsə bu satış miqdarı qədər parfum `SalePrice Table`na qayıdır.
### Database Schema
<img src="https://i.postimg.cc/9XBJdgTn/Parfums-DBDesigners.png">







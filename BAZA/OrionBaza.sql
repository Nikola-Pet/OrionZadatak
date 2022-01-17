Create database Orion
Go

Use Orion
Go

Create table Paket(
PaketId int identity(1,1) not null,
Naziv nvarchar(max) not null,
Opis nvarchar(max) not null,
Cena int not null,
Kategorija nvarchar(max) not null
)

Create table Ugovor(
BrojUgovora int identity(1,1) not null,
KorisnickoIme nvarchar (max) not null,
TrajanjeUgovorneObaveze int not null,
Popust int not null,
GratisPeriod int not null,
PaketId int not null,
Status bit not null,
DatumKreiranja datetime not null
)

Create table Istorija(
Id int identity(1,1) not null,
BrojUgovora int not null,
Datum datetime not null,
Status bit not null,
Suma int not null
)

Alter table Paket
Add constraint PK_Paket primary key (PaketId)

Alter table Ugovor
Add constraint PK_Ugovor primary key (BrojUgovora)

Alter table Istorija
Add constraint PK_Istorija primary key (Id)

Go	

Create procedure INS_Paket(
@Naziv nvarchar(max),
@Opis nvarchar(max),
@Cena int,
@Kategorija nvarchar(max)
)
As
Begin
Begin transaction
Insert into
Paket(Naziv, Opis, Cena, Kategorija)
values
(@Naziv, @Opis, @Cena, @Kategorija)
If @@ERROR<>0
Begin
Rollback transaction
End
Else
Begin
Commit transaction
End
End

Go

Create procedure INS_Ugovor(
@KorisnickoIme nvarchar(max),
@TrajanjeUgovorneObaveze int,
@Popust int,
@GratisPeriod int, 
@PaketId int,
@Status bit,
@DatumKreiranja datetime 
)
As
Begin
Begin transaction
Insert into
Ugovor(KorisnickoIme, TrajanjeUgovorneObaveze, Popust, GratisPeriod, PaketId, Status, DatumKreiranja)
values
(@KorisnickoIme, @TrajanjeUgovorneObaveze, @Popust, @GratisPeriod, @PaketId, @Status, @DatumKreiranja)
If @@ERROR<>0
Begin
Rollback transaction
End
Else
Begin
Commit transaction
End
End

Go

Create procedure INS_Istorija(
@BrojUgovora int,
@Datum datetime,
@Status bit,
@Suma int
)
As
Begin
Begin transaction
Insert into
Istorija(BrojUgovora, Datum, Status, Suma)
values
(@BrojUgovora, @Datum, @Status, @Suma)
If @@ERROR<>0
Begin
Rollback transaction
End
Else
Begin
Commit transaction
End
End

Go

Exec INS_Paket 'Internet','Internet paket brzine do 100 Mbps', 1500, 'NET'
Exec INS_Paket 'IPTV sport','Sportski kanali', 450, 'IPTV'
Exec INS_Paket 'Fiksna telefonija','Neograniceni minuti u zemlji', 800, 'VOICE'
Exec INS_Paket 'IPTV','Svi kanali', 100, 'IPTV'

Exec INS_Ugovor 'Nikola.pet', 24, 10, 0, 1, 1, '09/10/2021 12:00:00'
Exec INS_Ugovor 'Dejan', 12, 20, 3, 1, 1, '01/17/2021 15:00:00'
Exec INS_Ugovor 'Petar', 24, 0, 6, 1, 1, '02/8/2021 16:00:00'
Exec INS_Ugovor 'Lazar', 12, 10, 2, 1, 1, '02/12/2021 17:00:00'
Exec INS_Ugovor 'Milos', 24, 30, 1, 1, 1, '03/18/2021 18:00:00'
Exec INS_Ugovor 'Filip', 12, 0, 4, 1, 1, '03/22/2021 9:00:00'
Exec INS_Ugovor 'Jovan', 24, 10, 5, 1, 1, '04/14/2021 10:00:00'
Exec INS_Ugovor 'Milica', 12, 20, 2, 1, 1, '04/23/2021 13:00:00'
Exec INS_Ugovor 'Ljubica', 24, 30, 3, 1, 1, '05/04/2021 14:00:00'
Exec INS_Ugovor 'Jelena', 12, 0, 4, 1, 0, '05/19/2021 12:00:00'
Exec INS_Ugovor 'Olja', 24, 20, 3, 1, 0, '06/03/2021 16:00:00'
Exec INS_Ugovor 'Tanja', 12, 10, 6, 1, 0, '06/07/2021 15:00:00'
Exec INS_Ugovor 'Stefan', 24, 20, 2, 1, 0, '07/10/2021 11:00:00'
Exec INS_Ugovor 'Uros', 12, 10, 3, 1, 0, '07/18/2021 10:00:00'
Exec INS_Ugovor 'Dragana', 24, 0, 0, 1, 1, '08/29/2021 18:00:00'

Exec INS_Istorija 1, '10/10/2021 15:00:00', 1, 1200
Exec INS_Istorija 1, '11/21/2021 13:00:00', 0, 1200
Exec INS_Istorija 1, '01/10/2022 10:00:00', 1, 1000





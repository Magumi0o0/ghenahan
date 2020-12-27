create table SavingPost(
ID int primary key identity, 
PID int foreign key references Posts(ID),
suID int foreign key references Users(ID),
SPDate datetime 
);
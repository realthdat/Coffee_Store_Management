CREATE DATABASE PiStoreManagement

CREATE TABLE Employee (
    ID VARCHAR(255) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Phone VARCHAR(15),
    Address VARCHAR(255),
    Salary DECIMAL(10, 2),
    HireDate DATE
);

CREATE TABLE Account (
    ID VARCHAR(255) PRIMARY KEY,
    Username VARCHAR(255) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    EmployeeID VARCHAR(255),
    Role VARCHAR(50),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(ID)
);

CREATE TABLE Client (
    ID VARCHAR(255) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Phone VARCHAR(15),
    Address VARCHAR(255)
);

CREATE TABLE Product (
    ID VARCHAR(255) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL
);


CREATE TABLE Orders (
    ID VARCHAR(255) PRIMARY KEY,
    ClientID VARCHAR(255),
    EmployeeID VARCHAR(255),
    OrderDate DATE,
    TotalPrice DECIMAL(10, 2),
    FOREIGN KEY (ClientID) REFERENCES Client(ID),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(ID)
);

CREATE TABLE OrderItem (
    ID VARCHAR(255) PRIMARY KEY,
    OrderID VARCHAR(255),
    ProductID VARCHAR(255),
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID),
    FOREIGN KEY (ProductID) REFERENCES Product(ID)
);

CREATE TABLE Bill (
    ID VARCHAR(255) PRIMARY KEY,
    OrderID VARCHAR(255),
    ClientID VARCHAR(255),
    EmployeeID VARCHAR(255),
    BillDate DATE,
    TotalPrice DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(ID),
    FOREIGN KEY (ClientID) REFERENCES Client(ID),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(ID)
);


INSERT INTO Employee (ID, Name, Email, Phone, Address, Salary, HireDate) VALUES
('E0001', 'John Doe', 'johndoe@example.com', '0123456789', '123 Elm St', 50000.00, '2022-01-15'),
('E0002', 'Jane Smith', 'janesmith@example.com', '0123456790', '456 Maple Ave', 52000.00, '2021-03-22'),
('E0003', 'Michael Brown', 'michaelb@example.com', '0123456791', '789 Oak Rd', 55000.00, '2020-11-10'),
('E0004', 'Emily Davis', 'emilyd@example.com', '0123456792', '321 Pine Ln', 53000.00, '2022-05-05'),
('E0005', 'Robert Wilson', 'robertw@example.com', '0123456793', '654 Cedar St', 60000.00, '2019-07-25'),
('E0006', 'Lisa Johnson', 'lisaj@example.com', '0123456794', '987 Birch Ct', 48000.00, '2020-09-10'),
('E0007', 'Chris White', 'chrisw@example.com', '0123456795', '741 Spruce Blvd', 57000.00, '2021-08-17'),
('E0008', 'David Green', 'davidg@example.com', '0123456796', '963 Ash Rd', 59000.00, '2023-02-20'),
('E0009', 'Jessica Black', 'jessicab@example.com', '0123456797', '852 Cherry Dr', 51000.00, '2022-12-14'),
('E0010', 'George Miller', 'georgem@example.com', '0123456798', '159 Walnut St', 62000.00, '2021-06-29');


INSERT INTO Account (ID, Username, PasswordHash, EmployeeID, Role)
VALUES 
('ACC001', 'john_doe', '5f4dcc3b5aa765d61d8327deb882cf99', 'E0001', 'admin'), 
('ACC002', 'jane_smith', '7c6a180b36896a0a8c02787eeafb0e4c', 'E0002', 'user'),
('ACC003', 'michael_brown', '25d55ad283aa400af464c76d713c07ad', 'E0003', 'manager'),
('ACC004', 'admin', '21232f297a57a5a743894a0e4a801fc3', 'E0004', 'admin');


INSERT INTO Client (ID, Name, Email, Phone, Address) VALUES
('C0001', 'Acme Corp', 'contact@acme.com', '0987654321', '1 Acme Way'),
('C0002', 'Beta Inc', 'info@beta.com', '0987654322', '42 Beta St'),
('C0003', 'Gamma Ltd', 'support@gamma.com', '0987654323', '128 Gamma Rd'),
('C0004', 'Delta LLC', 'sales@delta.com', '0987654324', '563 Delta Blvd'),
('C0005', 'Epsilon Enterprises', 'contact@epsilon.com', '0987654325', '978 Epsilon Ct'),
('C0006', 'Zeta Group', 'info@zeta.com', '0987654326', '654 Zeta Ave'),
('C0007', 'Theta Solutions', 'support@theta.com', '0987654327', '742 Theta Dr'),
('C0008', 'Iota Systems', 'sales@iota.com', '0987654328', '111 Iota Rd'),
('C0009', 'Kappa Technologies', 'info@kappa.com', '0987654329', '369 Kappa St'),
('C0010', 'Lambda Services', 'contact@lambda.com', '0987654330', '852 Lambda Blvd');

INSERT INTO Product (ID, Name, Description, Price, Quantity) VALUES
('P0001', 'Laptop', 'High-performance laptop with Intel i7 processor, 16GB RAM, 512GB SSD, and a 15.6-inch Full HD display, perfect for gaming and professional work.', 1500.00, 20),
('P0002', 'Smartphone', 'Latest model smartphone with 6.5-inch OLED display, 128GB storage, 5G connectivity, triple-camera system, and fast charging capabilities.', 800.00, 50),
('P0003', 'Tablet', 'Lightweight tablet with a 10.1-inch screen, 64GB storage, and long-lasting battery, ideal for media consumption, reading, and light productivity tasks.', 500.00, 30),
('P0004', 'Smartwatch', 'Waterproof smartwatch with fitness tracking, heart rate monitoring, GPS, and support for notifications and music playback.', 250.00, 40),
('P0005', 'Headphones', 'Noise-cancelling over-ear headphones with superior sound quality, wireless connectivity, and 30 hours of battery life, ideal for travel and work.', 120.00, 60),
('P0006', 'Monitor', '27-inch 4K resolution monitor with HDR support, 60Hz refresh rate, and thin bezels for immersive viewing and gaming experiences.', 300.00, 25),
('P0007', 'Keyboard', 'Mechanical keyboard with RGB lighting, durable switches, and customizable keys for enhanced typing and gaming performance.', 100.00, 45),
('P0008', 'Mouse', 'Wireless ergonomic mouse with adjustable DPI, silent clicking, and long battery life, suitable for both work and gaming.', 50.00, 70),
('P0009', 'Printer', 'All-in-one printer with scanning, copying, and faxing capabilities, supports wireless printing and high-quality color output.', 200.00, 15),
('P0010', 'Webcam', '1080p HD webcam with wide-angle lens, built-in microphone, and auto-focus, ideal for video conferencing and streaming.', 80.00, 35);



INSERT INTO Orders (ID, ClientID, EmployeeID, OrderDate, TotalPrice) VALUES
('O0001', 'C0001', 'E0001', '2024-09-01', 2500.00),
('O0002', 'C0002', 'E0002', '2024-09-05', 1600.00),
('O0003', 'C0003', 'E0003', '2024-09-10', 800.00),
('O0004', 'C0004', 'E0004', '2024-09-12', 3200.00),
('O0005', 'C0005', 'E0005', '2024-09-15', 500.00),
('O0006', 'C0006', 'E0006', '2024-09-18', 1200.00),
('O0007', 'C0007', 'E0007', '2024-09-20', 900.00),
('O0008', 'C0008', 'E0008', '2024-09-22', 2800.00),
('O0009', 'C0009', 'E0009', '2024-09-25', 1800.00),
('O0010', 'C0010', 'E0010', '2024-09-28', 4000.00);


INSERT INTO OrderItem (ID, OrderID, ProductID, Quantity) VALUES
('OI0001', 'O0001', 'P0001', 1),
('OI0002', 'O0001', 'P0002', 1),
('OI0003', 'O0002', 'P0003', 2),
('OI0004', 'O0002', 'P0004', 1),
('OI0005', 'O0003', 'P0005', 4),
('OI0006', 'O0004', 'P0006', 2),
('OI0007', 'O0005', 'P0007', 3),
('OI0008', 'O0006', 'P0008', 5),
('OI0009', 'O0007', 'P0009', 1),
('OI0010', 'O0008', 'P0010', 6);


INSERT INTO Bill (ID, OrderID, ClientID, EmployeeID, BillDate, TotalPrice) VALUES
('B0001', 'O0001', 'C0001', 'E0001', '2024-09-01', 2500.00),
('B0002', 'O0002', 'C0002', 'E0002', '2024-09-05', 1600.00),
('B0003', 'O0003', 'C0003', 'E0003', '2024-09-10', 800.00),
('B0004', 'O0004', 'C0004', 'E0004', '2024-09-12', 3200.00),
('B0005', 'O0005', 'C0005', 'E0005', '2024-09-15', 500.00),
('B0006', 'O0006', 'C0006', 'E0006', '2024-09-18', 1200.00),
('B0007', 'O0007', 'C0007', 'E0007', '2024-09-20', 900.00),
('B0008', 'O0008', 'C0008', 'E0008', '2024-09-22', 2800.00),
('B0009', 'O0009', 'C0009', 'E0009', '2024-09-25', 1800.00),
('B0010', 'O0010', 'C0010', 'E0010', '2024-09-28', 4000.00);

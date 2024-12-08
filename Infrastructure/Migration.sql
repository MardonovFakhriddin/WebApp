CREATE DATABASE "Company_DB"

CREATE TABLE Company
(
    company_id SERIAL PRIMARY KEY,
    company_name VARCHAR(255) NOT NULL,
    company_address VARCHAR(255),
    company_phone VARCHAR(15)
);

CREATE TABLE Department
(
    department_id SERIAL PRIMARY KEY,
    department_name VARCHAR(255) NOT NULL,
    company_id INT,
    FOREIGN KEY (company_id) REFERENCES Company(company_id) ON DELETE CASCADE
);

CREATE TABLE Branch
(
    branch_id SERIAL PRIMARY KEY,
    branch_name VARCHAR(255) NOT NULL,
    company_id INT,
    branch_address VARCHAR(255),
    FOREIGN KEY (company_id) REFERENCES Company(company_id) ON DELETE CASCADE
);

CREATE TABLE Employee
(
    employee_id SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(255) UNIQUE,
    phone_number VARCHAR(15),
    department_id INT,
    branch_id INT,
    FOREIGN KEY (department_id) REFERENCES Department(department_id) ON DELETE SET NULL,
    FOREIGN KEY (branch_id) REFERENCES Branch(branch_id) ON DELETE SET NULL
);

INSERT INTO Company (company_name, company_address, company_phone)
VALUES
    ('Tech Solutions', '123 Tech Street, Silicon Valley', '123-456-7890'),
    ('Green Innovations', '456 Green Road, Green City', '987-654-3210'),
    ('Future Enterprises', '789 Future Avenue, New York', '555-123-4567'),
    ('Global Corp', '321 Global Blvd, London', '444-555-6666'),
    ('Oceanic Ventures', '654 Ocean Drive, Sydney', '333-444-5555');

INSERT INTO Department (department_name, company_id)
VALUES
    ('Research and Development', 1),
    ('Marketing', 2),
    ('Sales', 3),
    ('Human Resources', 4),
    ('Finance', 5);

INSERT INTO Branch (branch_name, company_id, branch_address)
VALUES
    ('Head Office', 1, '123 Tech Street, Silicon Valley'),
    ('Regional Office', 2, '456 Green Road, Green City'),
    ('Main Branch', 3, '789 Future Avenue, New York'),
    ('International Office', 4, '321 Global Blvd, London'),
    ('Sydney Office', 5, '654 Ocean Drive, Sydney');

INSERT INTO Employee (full_name, email, phone_number, department_id, branch_id)
VALUES
    ('Alice Johnson', 'alice.johnson@techsolutions.com', '111-222-3333', 1, 1),
    ('Bob Smith', 'bob.smith@greeninnovations.com', '444-555-6666', 2, 2),
    ('Charlie Brown', 'charlie.brown@futureenterprises.com', '777-888-9999', 3, 3),
    ('David Wilson', 'david.wilson@globalcorp.com', '123-456-7890', 4, 4),
    ('Eva Adams', 'eva.adams@oceanicventures.com', '999-000-1111', 5, 5);



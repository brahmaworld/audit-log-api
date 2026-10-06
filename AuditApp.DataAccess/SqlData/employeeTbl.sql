CREATE TABLE employee (
    id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    gender VARCHAR(50) NOT NULL,
    email VARCHAR(255) NOT NULL,
    salary NUMERIC(10, 2) NOT NULL,
    password VARCHAR(255) NOT NULL
);

CREATE UNIQUE INDEX uq_employee_email
ON employee (email);
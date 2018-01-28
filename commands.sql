--query to create empty ROLES table
CREATE TABLE roles (
        roleId INT AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(20) NOT NULL,
        lft INT NOT NULL,
        rgt INT NOT NULL
);

--query to create empty PERMISSIONS table
CREATE TABLE permissions (
        permissionId INT AUTO_INCREMENT PRIMARY KEY,
        roleId INT NOT NULL,
        rowId INT NOT NULL,
        selectPermission TINYINT(1) NOT NULL,
	editionPermission TINYINT(1) NOT NULL
);

--query to create empty USERS table
CREATE TABLE users (
        userId INT AUTO_INCREMENT PRIMARY KEY,
        roleId INT NOT NULL,
        name VARCHAR(20) NOT NULL
);


INSERT INTO roles VALUES
 (1,'administrators',1,14),
 (2,'accountancy manager',2,7),
 (3,'accountant',3,4),
 (4,'simple employer',5,6),
 (5,'director',8,13),
 (6,'marketing manager',9,10),
 (7,'office manager',11,12);


--query to receive @roleName transitive closure
SELECT node.roleId FROM roles AS parent, roles AS node
WHERE node.lft BETWEEN parent.lft AND parent.rgt
        AND parent.name = '@roleName';

-- example query with authorisation
select * from templateTable natural join permissions as p where p.roleId in (SELECT node.roleId FROM roles AS parent, roles AS node
WHERE node.lft BETWEEN parent.lft AND parent.rgt
AND parent.name = 'accountancy manager') and selectPermission=1;



--add child role to e.g 'accountant'
LOCK TABLE roles WRITE;

SELECT @myLeft := lft FROM roles
WHERE name = 'accountant';

UPDATE roles SET rgt = rgt + 2 WHERE rgt > @myLeft;
UPDATE roles SET lft = lft + 2 WHERE lft > @myLeft;

INSERT INTO roles(name, lft, rgt) VALUES('trainee', @myLeft + 1, @myLeft + 2);

UNLOCK TABLES;
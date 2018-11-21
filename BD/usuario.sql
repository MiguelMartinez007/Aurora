drop user 'AURORA'@'localhost';
create user 'AURORA'@'localhost' identified by 'AURORA';
GRANT ALL privileges ON AURORA.* TO 'AURORA'@'localhost' identified by 'AURORA';

use mysql;
select * from user where user = "AURORA";
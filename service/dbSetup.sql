CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE sodas (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(100) NOT NULL,
  description TEXT,
  price DECIMAL(10,2) NOT NULL,
  image_url VARCHAR(255),
  stock INT DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);



DROP TABLE sodas;


DROP TABLE cart_items;

CREATE TABLE cart (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  creatorId VARCHAR(255) NOT NULL,
  user_id INT REFERENCES accounts(id) ON DELETE CASCADE,
  is_checked_out BOOLEAN DEFAULT FALSE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE

);
CREATE TABLE cart_items (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  cart_id INT NOT NULL,
  soda_id INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (cart_id) REFERENCES cart (id) ON DELETE CASCADE,
  FOREIGN KEY (soda_id) REFERENCES sodas (id) ON DELETE CASCADE,
      FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,

  quantity INT NOT NULL CHECK (quantity > 0),
  UNIQUE(cart_id, soda_id)
);
-- keepId INT NOT NULL,
-- vaultId INT NOT NULL,
-- FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
-- FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
-- FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE

CREATE TABLE orders (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  user_id INT NOT NULL,
  cart_id INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  total DECIMAL(10, 2) NOT NULL,
  status VARCHAR(20) DEFAULT 'Pending', -- e.g., Pending, Shipped, Delivered

  FOREIGN KEY (cart_id) REFERENCES cart(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
);


INSERT INTO
sodas (name, description, price, image_url, stock, creatorId)
VALUES
('Coke', 'Classic Coca-Cola soda', 1.50, 'https://images.unsplash.com/photo-1554866585-cd94860890b7?q=80&w=1530&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 100, '6691cd264de80d398f94368a'),
('Pepsi', 'Refreshing Pepsi soda', 1.50, 'https://plus.unsplash.com/premium_photo-1681487658177-36170fa6bb06?q=80&w=1760&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 100, '6691cd264de80d398f94368a'),
('Sprite', 'Lemon-lime flavored soda', 1.50, 'https://plus.unsplash.com/premium_photo-1681487652640-9257693221d5?q=80&w=1760&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 100, '6691cd264de80d398f94368a'),
('Fanta', 'Orange flavored soda', 1.50, 'https://example.com/fanta.jpg', 100, '6691cd264de80d398f94368a'),
('Dr Pepper', 'Unique blend of 23 flavors', 1.50, 'https://example.com/drpepper.jpg', 100, '6691cd264de80d398f94368a');
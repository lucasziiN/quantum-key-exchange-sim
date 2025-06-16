# Quantum Key Exchange Simulator – COMPX304 Assignment 3

A simulation of the **BB84 Quantum Key Exchange (QKE)** algorithm, paired with XOR-based symmetric encryption. Developed for COMPX304 – Advanced Networking & Cyber Security at the University of Waikato (2025).

This project demonstrates how quantum principles can be applied to securely establish a shared symmetric key, which is then used for encrypting a classical message.

---

## 🔐 Features

- Quantum Qubit class simulating polarization types (circular, linear)
- XOR encryption and decryption engine
- BB84 QKE protocol emulation: transmit, receive, and derive matching key bits
- Unit-tested on key edge cases and stream lengths: 16, 256, and 1024
- Structured and documented for reproducibility and learning

---

## 🧱 Architecture Overview

### 1. `Qubit` Class
- Randomly assigned values and polarization types
- Models quantum measurement via matching or mismatched filters

### 2. `XORCipher` Class
- Encrypts and decrypts binary messages using repeated XOR with key
- Handles binary strings and key cycling

### 3. `QKEProtocol` Module
- Simulates:
  - Transmitter generating qubits
  - Receiver measuring them
  - Polarization exchange to derive shared secret
- Filters matching polarizations for key bits

---

## 🛠 How It Works

```plaintext
1. Transmitter generates N random qubits (polarization + value)
2. Receiver measures them with random bases
3. Both exchange bases and keep bits where polarizations match
4. Resulting binary key used for XOR encryption
5. Ciphertext is transmitted and decrypted using XOR + derived key
```

---

## 📊 Tests & Evaluation

- Qubit class tested with valid/mismatched polarization filters
- XORCipher tested with edge cases and long binary strings
- QKE tested with:
  - 16-bit stream (basic validation)
  - 256-bit stream (medium test)
  - 1024-bit stream (realistic use case)

---

## ✅ Example Output:

Original Message: 01001101...
Generated Key:   10010100...
Encrypted:       11011001...
Decrypted:       01001101... ✅

--- 

## 📁 Project Structure

qke-simulator/
├── qubit.py
├── xor_cipher.py
├── qke_protocol.py
├── test_qubit.py
├── test_xor_cipher.py
├── test_qke.py
└── README.md

---

## 📄 Report

The report (submitted via Moodle) includes:

- Design explanation 
- Unit testing methodology and results
- Evaluation and reflection on QKE outcomes

---

## 👨‍🎓 Author

Lucas Oda
Bachelor of Science (Computer Science Major)
University of Waikato
COMPX304 – Assignment 3 (2025)

---

## 📜 License

This project is for educational use under the University of Waikato's academic guidelines.




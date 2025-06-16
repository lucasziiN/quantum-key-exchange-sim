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

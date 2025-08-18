document.getElementById('colorBtn').addEventListener('click', function () {
  this.classList.toggle('active');

  // Example: Send data to server (C# backend)
  fetch('/api/button', {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({active: this.classList.contains('active')})
  });
});
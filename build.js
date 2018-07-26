var exec = require('child_process').exec;

var os = require('os');

if (os.type() === 'Linux') 
    exec("cd .paket && mono paket.exe install", console.log); 
else if (os.type() === 'Darwin') 
    exec("cd .paket && mono paket.exe install", console.log); 
else if (os.type() === 'Windows_NT') 
    exec("cd .paket && paket.exe install", console.log); 
else
    throw new Error("Unsupported OS found: " + os.type());
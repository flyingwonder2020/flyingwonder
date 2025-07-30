const fs = require("fs");
const path = require("path");

const baseDir = __dirname;   // where this script is located
const outputFile = path.join(baseDir, "images.json");

// 📂 Folders you want to scan
const folders = [
  "raptors_small",
  "owls_small",
  "waders_small",
  "bulbuls_small",
  "flycatchers_small",
  "frogmouth_small",
  "kingfishers_small",
  "misc_small",
  "odkf_small",
  "storks_small",
  "trogon_small",
  "others_small",
  "woodpecker_small"
];

// 🏗 Build the JSON object
const result = {};

folders.forEach(folder => {
  const folderPath = path.join(baseDir, folder);

  if (fs.existsSync(folderPath)) {
    const files = fs.readdirSync(folderPath).filter(file => {
      return file.match(/\.(jpg|jpeg|png|gif)$/i); // only image files
    });
    result[folder] = files;
  } else {
    console.warn(`⚠️ Folder not found: ${folder}`);
    result[folder] = [];
  }
});

// 💾 Write to images.json
fs.writeFileSync(outputFile, JSON.stringify(result, null, 2));

console.log("✅ images.json has been generated!");

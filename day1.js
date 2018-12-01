const fs = require('fs')
const lines = fs.readFileSync('day1.txt', { encoding: 'utf8' }).split('\n')

function part1 () {
  let freq = 0
  lines.forEach(line => {
    const op = line.slice(0, 1)
    const n = parseInt(line.slice(1), 10)
    if (op === '+') freq += n
    else freq -= n
  })
  console.log(freq)
}

function part2 () {
  let map = {}
  let freq = 0
  while (true) {
    for (let i = 0; i < lines.length; i++) {
      const line = lines[i]
      const op = line.slice(0, 1)
      const n = parseInt(line.slice(1), 10)
      if (op === '+') freq += n
      else freq -= n
      if (map[freq.toString()]) return console.log(freq)
      map[freq.toString()] = true
    }
  }
}

// part1()
part2()
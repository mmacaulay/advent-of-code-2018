const fs = require('fs')
const lines = fs.readFileSync('day1.txt', { encoding: 'utf8' }).split('\n')

function run () {
  let freq = 0
  lines.forEach(line => {
    const op = line.slice(0, 1)
    const n = parseInt(line.slice(1), 10)
    if (op === '+') freq += n
    else freq -= n
  })
  console.log(freq)
}

run()
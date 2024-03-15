import { useEffect, useState } from 'react';
import { Bowler } from '../types/Bowler';

function BowlerList() {
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);

  useEffect(() => {
    const fetchbowlerData = async () => {
      const rsp = await fetch('http://localhost:5142/Bowler');
      const b = await rsp.json();
      setBowlerData(b);
    };
    fetchbowlerData();
  }, []);

  return (
    <>
      <div className="row">
        <h4 className="text-center">Best Bowlers</h4>
      </div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>BowlerName</th>
            <th>TeamName</th>
            <th>BowlerAddress</th>
            <th>BowlerCity</th>
            <th>BowlerState</th>
            <th>BowlerZip</th>
            <th>BowlerPhoneNumber</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map((b) => (
            <tr key={b.bowlerID}>
              <td>{`${b.bowlerFirstName} ${b.bowlerMiddleInit ? b.bowlerMiddleInit + '. ' : ''}${b.bowlerLastName}`}</td>
              <td>{b.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;

import React, { useState, useEffect} from "react";
import { Map, Marker } from "pigeon-maps";
import { stamenToner } from 'pigeon-maps/providers';


export function PropertyMap({ properties }) {

    const [hue, setHue] = useState(0)
    const color = `hsl(${hue % 360}deg 39% 70%)`
    const [propertyState, setPropertyState] = useState([])
    
    
    useEffect(() => {

        setPropertyState(properties)
       
}, [properties])
    
    console.dir(propertyState);
    return (
        <div>
          <Map
            provider={stamenToner}
            dprs={[1, 2]} // this provider supports HiDPI tiles
            height={500}
            defaultCenter={[53.4808, -2.2426]}
                defaultZoom={11}>



             {propertyState.map(x =>
                 <Marker
                     key={x.id}
                        width={100}
                        anchor={[x.latitude, x.longitude]}
                        color={color}
                        onClick={() => setHue(hue + 20)}
                    />)}

               
                </Map >
                </div>
    )
}
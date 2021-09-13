using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WhiteWolf {

    [System.Serializable]
    public class Elements {

        public string name;

        [Space]

        public Color color;
        public GameObject element;

    }

    public class WW_LevelGenerator : MonoBehaviour {

        public Texture2D map;
        public Transform level;
        public Elements[] elements;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        int pos_x, pos_y;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void Start(){

            pos_x = -( map.width / 2 );
            pos_y = -( map.height / 2 );

            Generator();
        
        }

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void Generator(){

            for ( int x=0; x< map.width; x++ ){
                for ( int y=0; y<map.height; y++ ){
                    GenerateTile( x, y );
                }
            }

        }

        void GenerateTile( int x, int y ){

            Color pixelColor = map.GetPixel( x, y );

            if ( pixelColor.a == 0 ){ return;  }

            foreach ( Elements el in elements ) {

                if ( el.color.Equals( pixelColor ) ){

                     Vector2 pos = new Vector2( pos_x + x, pos_y + y );
                    GameObject obj = Instantiate ( el.element, pos, Quaternion.identity, level );
                    obj.name = el.name;

                }

            }

        }

    }

}
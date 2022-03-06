using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounderies : MonoBehaviour {
    [SerializeField] private Transform leftBoundery;
    [SerializeField] private Transform rightBoundery;

    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;


    //initial scale
    private Vector3 initScale;

    private bool movingLeft;

    private void Awake() {
        //This is the enemy's local scale at the beginning of the game
        initScale = enemy.localScale;

    }

    private void Update() {
        if (movingLeft) {
            if (enemy.position.x >= leftBoundery.position.x) {
                MoveInDirection(1);
            }
            else {
                //change direction
                ChangeDirection();
            }
        }
        else {
            if (enemy.position.x <= rightBoundery.position.x) { 
                MoveInDirection(-1);
            }
            else {
                //change direction
                ChangeDirection();
            }

        }
    }

    //This function will handle turning the enemy around
    private void ChangeDirection() { 
        movingLeft = !movingLeft;
    }

    //This method will help the enemy face the correct direction
    //And then move in that direction
    private void MoveInDirection(int _direction) {
        //Enemy face the correct direction
        //I am using Mathf.Abs() because the localScale.z could be positive or negative and I only want positive numbers there
        //because the _direction will indicate whether to the right or left (positive or negative)
        enemy.localScale = new Vector3(initScale.x, initScale.y, Mathf.Abs(initScale.z) * _direction);

        //Move in the direction
        //when _direction is negative, it moves to the left
        //when _direction is positive, it moves to the right
        enemy.position = new Vector3(enemy.position.x + -(_direction) * Time.deltaTime * speed,
            enemy.position.y, enemy.position.z);
    }
}

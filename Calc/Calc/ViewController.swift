//
//  ViewController.swift
//  Calc
//
//  Created by Кирилл Кожакин on 16.03.2020.
//  Copyright © 2020 Kozhakin Kirill. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    var numberFromScreen:Double = 0
    @IBOutlet weak var firstNumLabel: UILabel!
    var firstNum:Double = 0
    var mathSign:Bool = false
    var operation:Int = 0
    var f:Bool = false
    
    @IBOutlet weak var result: UILabel!
    @IBAction func point(_ sender: UIButton) {
        if !result.text!.contains("."){
            result.text = result.text! + "."
        } else {
            result.text = result.text!.replacingOccurrences(of: ".", with: "")
        }
        numberFromScreen = Double(result.text!)!
        if f {
            firstNum = numberFromScreen
        }
    }
    
    @IBAction func digits(_ sender: UIButton) {
        if mathSign || result.text == "0" || result.text == "nan" {
            result.text = String(sender.tag)
            mathSign = false
        }
        else {
            result.text = result.text! + String(sender.tag)
        }
        numberFromScreen = Double(result.text!)!
    }
    
    func factorial(_ n: Int) -> Double {
      return (1...n).map(Double.init).reduce(1.0, *)
    }
    
    func isInt(text:String) -> Bool {
        guard let _ = Int(text) else { return false }
        return true
    }
    
    @IBAction func unaryOper(_ sender: UIButton)
    {
        if result.text != "nan" {
            firstNumLabel.text = String(firstNum)
            switch sender.tag {
            case 19:
                numberFromScreen = -Double(result.text!)!
            case 20:
                numberFromScreen = M_E
            case 21:
                numberFromScreen = Double.pi
            case 22:
                numberFromScreen = log(Double(result.text!)!)
            case 23:
                numberFromScreen = pow(Double(result.text!)!, 0.5)
            case 24:
                if isInt(text: result.text!) {
                    numberFromScreen = factorial(Int(result.text!)!)
                }
                else {
                    numberFromScreen = 0
                    result.text = "nan"
                }
            case 25:
                numberFromScreen = log10(Double(result.text!)!)
            case 26:
                numberFromScreen = pow(10, Double(result.text!)!)
            case 27:
                numberFromScreen = exp(Double(result.text!)!)
            case 28:
                numberFromScreen = pow(Double(result.text!)!, 2)
            case 29:
                numberFromScreen = sin(Double(result.text!)!)
            case 30:
                numberFromScreen = cos(Double(result.text!)!)
            case 31:
                numberFromScreen = tan(Double(result.text!)!)
            case 32:
                numberFromScreen = 1 / Double(result.text!)!
            case 15:
                numberFromScreen = Double(result.text!)! / 100
            default:
                numberFromScreen = 0
            }
            if result.text != "nan" {
                result.text = String(numberFromScreen)
            }
        }
    }
    
    @IBAction func buttons(_ sender: UIButton) {
        if sender.tag == 10 {
            firstNum = 0
            operation = 0
            numberFromScreen = 0
            result.text = "0"
        }
        if result.text != "nan" {
            if sender.tag > 10 && sender.tag < 17 {
                if !f {
                    if firstNum != 0 {
                        switch operation {
                        case 11:
                            firstNum = firstNum / numberFromScreen
                        case 12:
                            firstNum = firstNum * numberFromScreen
                        case 13:
                            firstNum = firstNum - numberFromScreen
                        case 14:
                            firstNum = firstNum + numberFromScreen
                        case 16:
                            firstNum = pow(firstNum, numberFromScreen)
                        case 17:
                            firstNum = pow(firstNum, 1 / numberFromScreen)
                        default:
                            firstNum = 0
                        }
                    }
                    else {
                        firstNum = Double(result.text!)!
                    }
                }
                f = false
                
                switch sender.tag {
                case 11:
                    result.text = "/"
                case 12:
                    result.text = "x"
                case 13:
                    result.text = "-"
                case 14:
                    result.text = "+"
                case 16:
                    result.text = "^"
                case 17:
                    result.text = "√"
                default:
                    result.text = "0"
                }
                mathSign = true
                operation = sender.tag
            }
            else
                if sender.tag == 18 {
                    f = true
                    switch operation {
                    case 11:
                        firstNum = firstNum / numberFromScreen
                    case 12:
                        firstNum = firstNum * numberFromScreen
                    case 13:
                        firstNum = firstNum - numberFromScreen
                    case 14:
                        firstNum = firstNum + numberFromScreen
                    case 16:
                        firstNum = pow(firstNum, numberFromScreen)
                    case 17:
                        firstNum = numberFromScreen / 100
                    default:
                        firstNum = 0
                    }
                    result.text = String(firstNum)
            }
            firstNumLabel.text = String(firstNum)
        }
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }


}


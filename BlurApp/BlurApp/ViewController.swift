//
//  ViewController.swift
//  BlurApp
//
//  Created by Кирилл Кожакин on 22.02.2020.
//  Copyright © 2020 Kozhakin Kirill. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet var backgroundImageView:UIImageView!
    @IBOutlet var loginImageView:UIImageView!
    
    let imageSet = ["cloud.jpg", "coffee.jpg", "food.jpg", "pmq.jpg", "temple.jpg"]
    var blurEffectView: UIVisualEffectView?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Randomly pick an image
        let selectedImageIndex = Int(arc4random_uniform(5))
        // Apply blurring effect
        backgroundImageView.image = UIImage(named: imageSet[selectedImageIndex])
        loginImageView.image = UIImage(named: "login.jpg")
        let blurEffect = UIBlurEffect(style: UIBlurEffect.Style.light)
        blurEffectView = UIVisualEffectView(effect: blurEffect)
        blurEffectView?.frame = view.bounds
        backgroundImageView.addSubview(blurEffectView!)
    }
    
    override func traitCollectionDidChange(_ previousTraitCollection: UITraitCollection?) {
    blurEffectView?.frame = view.bounds
        
    }

}


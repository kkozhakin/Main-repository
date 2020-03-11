//
//  TripCollectionViewCell.swift
//  TripCard
//
//  Created by Кирилл Кожакин on 27.02.2020.
//  Copyright © 2020 Kirill Kozhakin. All rights reserved.
//

import UIKit

protocol TripCollectionCellDelegate {
    func didLikeButtonPressed(cell: TripCollectionViewCell)
}

class TripCollectionViewCell: UICollectionViewCell {
    @IBOutlet var imageView: UIImageView!
    @IBOutlet var cityLabel: UILabel!
    @IBOutlet var countryLabel: UILabel!
    @IBOutlet var totalDaysLabel: UILabel!
    @IBOutlet var priceLabel: UILabel!
    @IBOutlet var likeButton: UIButton!
    var delegate:TripCollectionCellDelegate?
    @IBAction func likeButtonTapped(sender: AnyObject) {
        delegate?.didLikeButtonPressed(cell: self)
    }
    var isLiked:Bool = false {
        didSet {
            if isLiked {
                likeButton.setImage(UIImage(named: "heartfill"), for: .normal)
            }
            else {
                likeButton.setImage(UIImage(named: "heart"), for: .normal)
            }
        }
    }
}

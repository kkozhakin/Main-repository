//
//  ViewController.swift
//  TripCard
//
//  Created by HSE FKN on 03.02.2020.
//  Copyright © 2020 Kirill Kozhakin. All rights reserved.
//

import UIKit
import Parse

class TripViewController: UIViewController, UICollectionViewDelegate, UICollectionViewDataSource, TripCollectionCellDelegate, UIGestureRecognizerDelegate {

    @IBOutlet var collectionView: UICollectionView!
    @IBAction func reloadButtonTapped(sender: Any) {
        loadTripsFromParse()
    }
    
    private var trips = [Trip]()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        loadTripsFromParse()
        collectionView.backgroundColor = UIColor.clear
        if UIScreen.main.bounds.size.height == 568.0 {
            let flowLayout = self.collectionView.collectionViewLayout as! UICollectionViewFlowLayout
            flowLayout.itemSize = CGSize(width: 250.0, height: 330.0)
        }
        // Setup swipe gesture
        let swipeUpRecognizer = UISwipeGestureRecognizer(target: self, action: "handleSwipe:")
        swipeUpRecognizer.direction = .up
        swipeUpRecognizer.delegate = self as? UIGestureRecognizerDelegate
        self.collectionView.addGestureRecognizer(swipeUpRecognizer)
    }
    
    func loadTripsFromParse() {
        // Clear up the array
        trips.removeAll(keepingCapacity: true)
        collectionView.reloadData()
        // Pull data from Parse
        let query = PFQuery(className: "Trip")
        query.cachePolicy = PFCachePolicy.networkElseCache
        query.findObjectsInBackground { (objects, error) -> Void in
            if let error = error {
                print("Error: \(error) \(error.localizedDescription)")
                return
            }
            if let objects = objects {
                for (index, object) in objects.enumerated() {
                    // Convert PFObject into Trip object
                    let trip = Trip(pfObject: object)
                    self.trips.append(trip)
                    let indexPath = IndexPath(row: index, section: 0)
                    self.collectionView.insertItems(at: [indexPath])
                }
            }
        }
    }
    
    func handleSwipe(gesture: UISwipeGestureRecognizer) {
        let point = gesture.location(in: self.collectionView)
        if (gesture.state == UIGestureRecognizer.State.ended) {
            if let indexPath = collectionView.indexPathForItem(at: point) {
                // Remove trip from Parse, array and collection view
                trips[indexPath.row].toPFObject().deleteInBackground(block: { (success, error) -> Void in
                    if (success) {
                        print("Successfully removed the trip")
                    } else {
                        print("Error: \(error?.localizedDescription)")
                        return
                    }
                    self.trips.remove(at: indexPath.row)
                    self.collectionView.deleteItems(at: [indexPath]) })
            }
        }
    }
    
    func numberOfSections(in collectionView: UICollectionView) -> Int {
        return 1
    }
    
    func collectionView(_ collectionView: UICollectionView, numberOfItemsInSection section: Int) -> Int {
        return trips.count
    }
    
    func collectionView(_ collectionView: UICollectionView, cellForItemAt indexPath: IndexPath) -> UICollectionViewCell {
        
        let cell = collectionView.dequeueReusableCell(withReuseIdentifier: "Cell", for: indexPath) as! TripCollectionViewCell
        // Configure the cell
        cell.cityLabel.text = trips[indexPath.row].city
        cell.countryLabel.text = trips[indexPath.row].country
        
        cell.imageView.image = UIImage()
        if let featuredImage = trips[indexPath.row].featuredImage {
            featuredImage.getDataInBackground(block: { (imageData, error) in
                if let tripImageData = imageData {
                    cell.imageView.image = UIImage(data: tripImageData)
                }
            })
        }
        
        cell.priceLabel.text = "$\(String(trips[indexPath.row].price))"
        cell.totalDaysLabel.text = "\(trips[indexPath.row].totalDays) days"
        cell.isLiked = trips[indexPath.row].isLiked
        // Apply round corner
        cell.layer.cornerRadius = 4.0
        cell.delegate = self
        return cell
    }
    
    func didLikeButtonPressed(cell: TripCollectionViewCell) {
        if let indexPath = collectionView.indexPath(for: cell) {
            trips[indexPath.row].isLiked = trips[indexPath.row].isLiked ? false : true
            cell.isLiked = trips[indexPath.row].isLiked
            // Update the trip on Parse
            trips[indexPath.row].toPFObject().saveInBackground(block: { (success, error) -> Void in
                if (success) {
                    print("Successfully updated the trip")
                } else {
                    print("Error: \(error?.localizedDescription)")
                }
            })
        }
    }
}


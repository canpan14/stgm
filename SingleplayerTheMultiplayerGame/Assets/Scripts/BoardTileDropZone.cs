using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace STMG {
    public class BoardTileDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
        public void OnDrop(PointerEventData eventData) {
            HazardCard hzc = eventData.pointerDrag.GetComponent<HazardCard>();
            BoardTile thisTile = this.transform.GetComponent<BoardTile>();
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

            if (hzc != null) {
                if (hzc.type == HazardType.NATURALDISASTER) {
                    if (thisTile.naturalDisasterHere != null) {
                        return;
                    } else {
                        removeHazardFromPreviousBoardTileIfNeeded(d, hzc);
                        d.parentToReturnTo = this.transform;
                        thisTile.naturalDisasterHere = hzc;
                        return;
                    }
                } else {
                    if (thisTile.nonNaturalDisasterHere != null) {
                        return;
                    } else {
                        removeHazardFromPreviousBoardTileIfNeeded(d, hzc);
                        d.parentToReturnTo = this.transform;
                        thisTile.nonNaturalDisasterHere = hzc;
                        return;
                    }
                }
            }

            if (d != null) {
                d.parentToReturnTo = this.transform;
            }
        }

        public void OnPointerEnter(PointerEventData eventData) {
            if (eventData.pointerDrag == null) {
                return;
            }
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();



            if (d != null) {
                d.placeholderParent = this.transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData) {
            if (eventData.pointerDrag == null) {
                return;
            }
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && d.placeholderParent == this.transform) {
                d.placeholderParent = d.parentToReturnTo;
            }
        }

        public void removeHazardFromPreviousBoardTileIfNeeded(Draggable d, HazardCard c) {
            BoardTileDropZone dz = d.parentToReturnTo.transform.GetComponent<BoardTileDropZone>();

            if(dz != null ) {
                if (c.type == HazardType.NATURALDISASTER) {
                    dz.transform.GetComponent<BoardTile>().naturalDisasterHere = null;
                } else {
                    dz.transform.GetComponent<BoardTile>().nonNaturalDisasterHere = null;
                }
            }
        }
    }
}

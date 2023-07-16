using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsGridGenerator : LayoutGroup
{
    public int rows, columns;
    private const int MIN_CARDS = 4;
    public Vector2 cardSize;
    // Start is called before the first frame update
    private void checkGridSize()
    {
        if(rows <= 0 || columns == 0)
        {
            rows = columns= MIN_CARDS;
        }
    }
    public override void CalculateLayoutInputVertical()
    {
        checkGridSize();

        float parentWidth = rectTransform.rect.width,
                    parentHeight = rectTransform.rect.height,
                    cellWidth = parentWidth / columns,
                    cellHeight = parentHeight / rows;
        cardSize = new Vector2(cellWidth, cellHeight);

        for(int i = 0; i < rectChildren.Count; ++i)
        {
           int rowCount = i / columns,
               columnCount = i % columns;
            var item = rectChildren[i];
            var position = new Vector2(
                    cardSize.x * columnCount,
                    cardSize.y * rowCount
                );
            SetChildAlongAxis(item, 0, position.x, cardSize.x);
            SetChildAlongAxis(item, 1, position.y, cardSize.y);

            

        }
    }
    public override void SetLayoutHorizontal()
    {
        // throw new System.NotImplementedException();
        return;
    }

    public override void SetLayoutVertical()
    {
        // throw new System.NotImplementedException();
        return;
    }
    
}

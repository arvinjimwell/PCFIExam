
SELECT c.CustomerNo, i.UnitID, c.LastName, c.FirstName, c.MiddleName, cdtl.EquityTerm,
	cdtl.EquityAmount, cdtl.MAAmount, cdtl.MIR, cdtl.FIRE, cdtl.LoanAmt, cdtl.IntRate
FROM CustomerTbl c
INNER JOIN CustomerDtl cdtl ON c.CustomerNo = cdtl.CustomerNo
INNER JOIN InventoryTbl i ON c.UnitId = i.UnitId
WHERE SellingPrice = CASE WHEN i.Type = "Lot Only" THEN i.LotPrice ELSE i.HousePrice END

UPDATE CustomerDtl
SET IntRate = 21
WHERE CustomerDtl.CustomerNo = 739662


DELETE FROM CustomerDtl WHERE CustomerDtl.CustomerNo = 739664
DELETE FROM CustomerTbl WHERE CustomerTbl.CustomerNo = 739664
